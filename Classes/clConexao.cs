using System;
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

        public bool Execute(string sql)
        {

            bool r = false;

            try
            {
                var cmd = new SqlCommand(sql, Conexao);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Retorno = ex.Message;
            }

            return r;

        }

        public SqlDataReader ExecuteReader(string sql)
        {
            var cmd = new SqlCommand(sql, Conexao);
            return cmd.ExecuteReader();
        }

    }

}
