using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADO.NET_CRUD
{
    
    public class clConexao
    {

        public SqlConnection Conexao = new System.Data.SqlClient.SqlConnection();
        public string Retorno = "";

        public bool Abrir(string tServer, string tUsuario, string tSenha, string tDatabase)
        {

            bool r = false;

            try
            {
                Conexao.ConnectionString = "data source=" + tServer + ";user id = " + tUsuario + "; pwd=" + tSenha + "; initial catalog = " + tDatabase;
                Conexao.Open();
                r = true;
            }
            catch (Exception ex) 
            {
                Retorno = ex.Message;                
            }
            
            return r;

        }

        public void Fechar()
        {

            try
            {
                Conexao.Close();
            }
            catch (Exception)
            {
                
            }

        }

        public bool Salvar(string Tabela, string Select, string Where, List<SqlParameter> parametros)
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
            cmdSelect.Connection = Conexao;

            //cria comando update            
            cmdUpdate.CommandText = criar_comando_update(parametros, Tabela, Where);
            cmdUpdate.Connection = Conexao;

            //cria insert
            cmdInsert.CommandText = criar_comando_insert(parametros, Tabela);
            cmdInsert.Connection = Conexao;

            //cria update     
            for (int z = 0; z < parametros.Count; z++)
            {
                cmdUpdate.Parameters.Add(parametros[z]);
                cmdInsert.Parameters.Add(parametros[z]);
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
