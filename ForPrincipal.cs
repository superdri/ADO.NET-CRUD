using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ADO.NET_CRUD
{
    public partial class ForPrincipal : Form
    {
        public ForPrincipal()
        {
            InitializeComponent();
        }

        private void ForPrincipal_Load(object sender, EventArgs e)
        {
            txtOrigemServidor.Text = Microsoft.VisualBasic.Interaction.GetSetting("ADO.NET CRUD", "Origem", "Servidor", "");
            txtOrigemDatabase.Text = Microsoft.VisualBasic.Interaction.GetSetting("ADO.NET CRUD", "Origem", "Database", "");
            txtOrigemUsuario.Text = Microsoft.VisualBasic.Interaction.GetSetting("ADO.NET CRUD", "Origem", "Usuario", "");
            txtOrigemSenha.Text = Microsoft.VisualBasic.Interaction.GetSetting("ADO.NET CRUD", "Origem", "Senha", "");

            txtDestinoServidor.Text = Microsoft.VisualBasic.Interaction.GetSetting("ADO.NET CRUD", "Destino", "Servidor", "");
            txtDestinoDatabase.Text = Microsoft.VisualBasic.Interaction.GetSetting("ADO.NET CRUD", "Destino", "Database", "");
            txtDestinoUsuario.Text = Microsoft.VisualBasic.Interaction.GetSetting("ADO.NET CRUD", "Destino", "Usuario", "");
            txtDestinoSenha.Text = Microsoft.VisualBasic.Interaction.GetSetting("ADO.NET CRUD", "Destino", "Senha", "");
        }

        private string ConnectionString(string servidor, string usuario, string senha, string database)
        {
            return $"Provider=SQLOLEDB;Data Source={servidor};Initial Catalog={database};User ID={usuario};Password={senha};";
        }

        private void cmdCarregarEmpresas_Click(object sender, EventArgs e)
        {
            try
            {
                lstEmpresas.Items.Clear();
                using (var conn = new SqlConnection($"Server={txtOrigemServidor.Text};Database={txtOrigemDatabase.Text};User Id={txtOrigemUsuario.Text};Password={txtOrigemSenha.Text};"))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("SELECT id, cnpj, nome FROM Empresa ORDER BY id", conn))
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            var item = new ListViewItem(rd["id"].ToString());
                            item.SubItems.Add(rd["cnpj"].ToString());
                            item.SubItems.Add(rd["nome"].ToString());
                            lstEmpresas.Items.Add(item);
                        }
                    }
                }

                SalvarConfiguracao();
                lblStatus.Text = $"Empresas carregadas: {lstEmpresas.Items.Count}.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar empresas");
            }
        }

        private void cmdImportar_Click(object sender, EventArgs e)
        {
            var selecionados = lstEmpresas.CheckedItems.Cast<ListViewItem>().Select(i => int.Parse(i.Text)).ToList();
            if (!selecionados.Any())
            {
                MessageBox.Show("Selecione ao menos uma empresa no ListView.");
                return;
            }

            try
            {
                SalvarConfiguracao();
                lblStatus.Text = "Iniciando importação...";
                Application.DoEvents();

                var origemSql = $"Server={txtOrigemServidor.Text};Database={txtOrigemDatabase.Text};User Id={txtOrigemUsuario.Text};Password={txtOrigemSenha.Text};";
                var destinoMasterSql = $"Server={txtDestinoServidor.Text};Database=master;User Id={txtDestinoUsuario.Text};Password={txtDestinoSenha.Text};";
                var destinoSql = $"Server={txtDestinoServidor.Text};Database={txtDestinoDatabase.Text};User Id={txtDestinoUsuario.Text};Password={txtDestinoSenha.Text};";

                CriarBancoDestinoSeNaoExiste(destinoMasterSql, txtDestinoDatabase.Text);
                CopiarEstrutura(origemSql, destinoSql, txtOrigemDatabase.Text, txtDestinoDatabase.Text);
                CopiarDadosFiltrados(origemSql, destinoSql, selecionados);

                lblStatus.Text = "Importação finalizada com sucesso.";
                MessageBox.Show("Importação concluída com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro na importação");
            }
        }

        private void CriarBancoDestinoSeNaoExiste(string destinoMasterSql, string database)
        {
            using (var conn = new SqlConnection(destinoMasterSql))
            {
                conn.Open();
                var sql = $"IF DB_ID('{database.Replace("'", "''")}') IS NULL CREATE DATABASE [{database}]";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void CopiarEstrutura(string origemSql, string destinoSql, string dbOrigem, string dbDestino)
        {
            using (var origem = new SqlConnection(origemSql))
            using (var destino = new SqlConnection(destinoSql))
            {
                origem.Open();
                destino.Open();

                var sqlTabelas = @"SELECT TABLE_SCHEMA, TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'";
                var tabelas = new List<Tuple<string, string>>();

                using (var cmd = new SqlCommand(sqlTabelas, origem))
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        tabelas.Add(Tuple.Create(rd[0].ToString(), rd[1].ToString()));
                    }
                }

                foreach (var t in tabelas)
                {
                    var schema = t.Item1;
                    var table = t.Item2;
                    var script = $@"
IF OBJECT_ID('[{schema}].[{table}]') IS NULL
BEGIN
    SELECT TOP 0 * INTO [{schema}].[{table}] FROM [{dbOrigem}].[{schema}].[{table}]
END";
                    using (var cmd = new SqlCommand(script, destino))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void CopiarDadosFiltrados(string origemConnStr, string destinoConnStr, List<int> empIds)
        {
            var empList = string.Join(",", empIds);

            Type connType = Type.GetTypeFromProgID("ADODB.Connection");
            Type rsType = Type.GetTypeFromProgID("ADODB.Recordset");

            dynamic connOrigem = Activator.CreateInstance(connType);
            dynamic connDestino = Activator.CreateInstance(connType);
            connOrigem.Open(ConnectionString(txtOrigemServidor.Text, txtOrigemUsuario.Text, txtOrigemSenha.Text, txtOrigemDatabase.Text));
            connDestino.Open(ConnectionString(txtDestinoServidor.Text, txtDestinoUsuario.Text, txtDestinoSenha.Text, txtDestinoDatabase.Text));

            using (var sql = new SqlConnection(origemConnStr))
            {
                sql.Open();
                var tabelas = new List<string>();
                using (var cmd = new SqlCommand("SELECT TABLE_SCHEMA + '.' + TABLE_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='emp' GROUP BY TABLE_SCHEMA, TABLE_NAME", sql))
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        tabelas.Add(rd[0].ToString());
                    }
                }

                foreach (var tabela in tabelas)
                {
                    connDestino.Execute($"DELETE FROM {tabela} WHERE emp IN ({empList})");
                    dynamic rs = Activator.CreateInstance(rsType);
                    rs.Open($"SELECT * FROM {tabela} WHERE emp IN ({empList})", connOrigem, 0, 1);
                    while (!rs.EOF)
                    {
                        var campos = new List<string>();
                        var valores = new List<string>();
                        for (int i = 0; i < rs.Fields.Count; i++)
                        {
                            var nome = rs.Fields[i].Name.ToString();
                            var valor = rs.Fields[i].Value;
                            campos.Add($"[{nome}]");
                            valores.Add(SqlLiteral(valor));
                        }

                        connDestino.Execute($"INSERT INTO {tabela} ({string.Join(",", campos)}) VALUES ({string.Join(",", valores)})");
                        rs.MoveNext();
                    }

                    rs.Close();
                    lblStatus.Text = $"Importando tabela {tabela}...";
                    Application.DoEvents();
                }
            }

            connOrigem.Close();
            connDestino.Close();
        }

        private static string SqlLiteral(object value)
        {
            if (value == null || value == DBNull.Value) return "NULL";
            if (value is string || value is char) return "N'" + value.ToString().Replace("'", "''") + "'";
            if (value is DateTime dt) return "'" + dt.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'";
            if (value is bool b) return b ? "1" : "0";
            return Convert.ToString(value, System.Globalization.CultureInfo.InvariantCulture);
        }

        private void SalvarConfiguracao()
        {
            Microsoft.VisualBasic.Interaction.SaveSetting("ADO.NET CRUD", "Origem", "Servidor", txtOrigemServidor.Text);
            Microsoft.VisualBasic.Interaction.SaveSetting("ADO.NET CRUD", "Origem", "Database", txtOrigemDatabase.Text);
            Microsoft.VisualBasic.Interaction.SaveSetting("ADO.NET CRUD", "Origem", "Usuario", txtOrigemUsuario.Text);
            Microsoft.VisualBasic.Interaction.SaveSetting("ADO.NET CRUD", "Origem", "Senha", txtOrigemSenha.Text);

            Microsoft.VisualBasic.Interaction.SaveSetting("ADO.NET CRUD", "Destino", "Servidor", txtDestinoServidor.Text);
            Microsoft.VisualBasic.Interaction.SaveSetting("ADO.NET CRUD", "Destino", "Database", txtDestinoDatabase.Text);
            Microsoft.VisualBasic.Interaction.SaveSetting("ADO.NET CRUD", "Destino", "Usuario", txtDestinoUsuario.Text);
            Microsoft.VisualBasic.Interaction.SaveSetting("ADO.NET CRUD", "Destino", "Senha", txtDestinoSenha.Text);
        }
    }
}
