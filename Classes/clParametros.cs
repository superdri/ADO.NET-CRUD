using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADO.NET_CRUD
{

    public class clParametros
    {

        private System.Collections.Generic.List<SqlParameter> parametros =
            new System.Collections.Generic.List<SqlParameter> { };

        public string Tabela  { get; set; } = "";
        public string Where   { get; set; } = "";
        public string Retorno { get; set; } = "";

        public void Adicionar(object item)
        {
            Adicionar(item, nameof(item));
        }

        public void Adicionar(object item, string nome)
        {

            Type t = item.GetType();

            var tipoBD = System.Data.SqlDbType.NVarChar;
            
            //verifica o tipo de campo e usa para criar um parametro
            if (t.Equals(typeof(byte)))
                tipoBD = System.Data.SqlDbType.Int;
            else if (t.Equals(typeof(sbyte)))
                tipoBD = System.Data.SqlDbType.Int;
            else if (t.Equals(typeof(int)))
                tipoBD = System.Data.SqlDbType.Int;
            else if (t.Equals(typeof(long)))
                tipoBD = System.Data.SqlDbType.Int;
            else if (t.Equals(typeof(bool)))
                tipoBD = System.Data.SqlDbType.Int;
            else if (t.Equals(typeof(Boolean)))
                tipoBD = System.Data.SqlDbType.Int;
            else if (t.Equals(typeof(double)))
                tipoBD = System.Data.SqlDbType.Float;
            else if (t.Equals(typeof(DateTime)))
                tipoBD = System.Data.SqlDbType.DateTime;
            else if (t.Equals(typeof(string)))
                tipoBD = System.Data.SqlDbType.NVarChar;
            else if (t.Equals(typeof(String)))
                tipoBD = System.Data.SqlDbType.NVarChar;
            else
                tipoBD = System.Data.SqlDbType.NVarChar;

            var p = new SqlParameter("@" + nome, tipoBD, 0, nome);
            p.Value = item;

            //adiciona
            parametros.Add(p);

        }

        public bool Salvar()
        {
            
            //formatar?
            if (!Tabela.Contains("["))
                Tabela = "[" + Tabela + "]";

            bool r = Salvar(this.Tabela, "select * from " + Tabela, this.Where, this.parametros);
                       
            return r;

        }

        private bool Salvar(string Tabela, string Select, string Where, List<SqlParameter> parametros)
        {

            bool r = false;

            var da = new SqlDataAdapter();
            var ds = new System.Data.DataSet();
            var cmdSelect = new SqlCommand();
            var cmdInsert = new SqlCommand();
            var cmdUpdate = new SqlCommand();
            Boolean novo = false;

            //cria comando de select            
            cmdSelect.CommandText = Select + Where;
            cmdSelect.Connection = GlobalTools.Conexao.Conexao;

            //cria comando update            
            cmdUpdate.CommandText = criar_comando_update(parametros, Tabela, Where);
            cmdUpdate.Connection = GlobalTools.Conexao.Conexao;

            //cria insert
            cmdInsert.CommandText = criar_comando_insert(parametros, Tabela);
            cmdInsert.Connection = GlobalTools.Conexao.Conexao;

            //cria update     
            for (int z = 0; z < parametros.Count; z++)
            {
                
                cmdUpdate.Parameters.Add(new SqlParameter(parametros[z].ParameterName, parametros[z].SqlDbType, parametros[z].Size, parametros[z].SourceColumn));
                cmdUpdate.Parameters[cmdUpdate.Parameters.Count - 1].Value = parametros[z].Value;

                cmdInsert.Parameters.Add(new SqlParameter(parametros[z].ParameterName, parametros[z].SqlDbType, parametros[z].Size, parametros[z].SourceColumn));
                cmdInsert.Parameters[cmdUpdate.Parameters.Count - 1].Value = parametros[z].Value;

                //cmdUpdate.Parameters.Add(parametros[z]);
                //cmdInsert.Parameters.Add(parametros[z]);

            }

            //preenche o comando
            da.SelectCommand = cmdSelect;
            da.InsertCommand = cmdInsert;
            da.UpdateCommand = cmdUpdate;

            try
            {

                //carrega dados
                da.Fill(ds);

                //novo?
                novo = ds.Tables[0].Rows.Count == 0;

                //editar ou insert?
                if (novo)
                {
                    cmdInsert.ExecuteNonQuery();
                    r = true;
                }
                else
                {
                    cmdUpdate.ExecuteNonQuery();
                    r = true;
                }

            }
            catch (Exception ex)
            {
                r = false;
                Retorno = ex.Message;
            }

            return r;

        }

        /// <summary>
        /// Cria um comando UPDATE com os parametros e valores informados
        /// </summary>
        /// <param name="P"></param>
        /// <param name="Tabela"></param>
        /// <param name="Where"></param>
        /// <returns></returns>
        public string criar_comando_update(List<SqlParameter> P, String Tabela, String Where)
        {

            string c = "";
            int x = 0;

            //inicia
            c = "update " + Tabela + " set ";

            for (x = 0; x <= P.Count - 1; x++)
            {

                c = c + P[x].SourceColumn + "=" + P[x].ParameterName;

                if (x + 1 <= P.Count - 1)
                {
                    c = c + ", ";
                }

            }

            //where
            c = c + " " + Where;

            return c;

        }

        /// <summary>
        /// Cria um comando INSERT com os parametros e valores informados
        /// </summary>
        /// <param name="P"></param>
        /// <param name="Tabela"></param>
        /// <returns></returns>
        public string criar_comando_insert(List<SqlParameter> P, String Tabela)
        {

            string c = "";
            int x = 0;

            //inicia
            c = "insert into " + Tabela + "(";

            for (x = 0; x <= P.Count - 1; x++)
            {
                c = c + P[x].SourceColumn;

                if (x + 1 <= P.Count - 1)
                {
                    c = c + ", ";
                }

            }

            c = c + ") values (";

            for (x = 0; x <= P.Count - 1; x++)
            {
                c = c + P[x].ParameterName;

                if (x + 1 <= P.Count - 1)
                {
                    c = c + ", ";
                }

            }

            c = c + ")";

            return c;

        }

    }

}
