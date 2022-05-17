using System;
using System.Windows.Forms;

namespace ADO.NET_CRUD
{

    public partial class ForPrincipal : Form
    {
       
        public ForPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            txtSer.Text = Microsoft.VisualBasic.Interaction.GetSetting("ADO.NET CRUD", "Config", "Servidor", "");
            txtBan.Text = Microsoft.VisualBasic.Interaction.GetSetting("ADO.NET CRUD", "Config", "DataBase", "");
            txtPwd.Text = Microsoft.VisualBasic.Interaction.GetSetting("ADO.NET CRUD", "Config", "Senha", "");
            txtUsu.Text = Microsoft.VisualBasic.Interaction.GetSetting("ADO.NET CRUD", "Config", "Usuario", "");
                        
            dataGrid.CellDoubleClick += DataGrid_CellDoubleClick;

        }

        private void DataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {

                ForCadastro tela = new ForCadastro();
                tela.ID = Convert.ToInt32(dataGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                tela.ShowDialog();

                Listar();

            }

        }

        private void cmdConectar_Click(object sender, EventArgs e)
        {

            if (Abrir())
            {
                
                //salva
                Microsoft.VisualBasic.Interaction.SaveSetting("ADO.NET CRUD", "Config", "Servidor", txtSer.Text);
                Microsoft.VisualBasic.Interaction.SaveSetting("ADO.NET CRUD", "Config", "DataBase", txtBan.Text);
                Microsoft.VisualBasic.Interaction.SaveSetting("ADO.NET CRUD", "Config", "Senha", txtPwd.Text);
                Microsoft.VisualBasic.Interaction.SaveSetting("ADO.NET CRUD", "Config", "Usuario", txtUsu.Text);

                //ativa
                cmdListar.Enabled = true;
                cmdNovo.Enabled = true;
                cmdCriarTabela.Enabled = true;

            }          

        }

        bool Abrir()
        {

            if (!GlobalTools.Conexao.Abrir(txtSer.Text, txtUsu.Text, txtPwd.Text, txtBan.Text))
            {
                MessageBox.Show(GlobalTools.Conexao.Retorno);
                return false;
            }
            else
            {
                return true;
            }

        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
     
        private void cmdNovo_Click(object sender, EventArgs e)
        {
            ForCadastro tela = new ForCadastro();
            tela.ID = 0;
            tela.ShowDialog();
        }

        private void cmdCriarTabela_Click(object sender, EventArgs e)
        {

            string sql;
            sql = "Create table Clientes (";
            sql += " ID [int] IDENTITY (1, 1) NOT NULL primary key, ";
            sql += " nome nvarchar(50), ";
            sql += " email nvarchar(50), ";
            sql += " data smalldatetime ";
            sql += ")";

            if (!GlobalTools.Conexao.Execute(sql))
            {
                MessageBox.Show(GlobalTools.Conexao.Retorno);
            }
            else
            {
                MessageBox.Show("Tabela criada com sucesso");
            }

        }

        private void cmdListar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        void Listar()
        {

            string sql = "select * from clientes";

            var dt = new System.Data.DataTable();
            var da = new System.Data.SqlClient.SqlDataAdapter();
            var cmd = new System.Data.SqlClient.SqlCommand(sql, GlobalTools.Conexao.Conexao);

            da.SelectCommand = cmd;
            da.Fill(dt);

            dataGrid.DataSource = dt.DefaultView;
            dataGrid.AutoGenerateColumns = true;
            dataGrid.AllowUserToDeleteRows = false;

        }

    }

}
