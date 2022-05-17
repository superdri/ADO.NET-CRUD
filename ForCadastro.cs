using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO.NET_CRUD
{

    public partial class ForCadastro : Form
    {

        public int ID = 0;

        public ForCadastro()
        {
            InitializeComponent();
        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            
            var P = new clParametros();

            P.Adicionar(txtEmail.Text, "email");
            P.Adicionar(txtNome.Text, "nome");
            P.Adicionar(txtData.Value, "data");            
            P.Tabela = "clientes";
            P.Where = " where id = " + txtID.Text;                  
            
            if (P.Salvar())
            {
                this.Close();
                this.Dispose();
            }
            else
            {
                MessageBox.Show(P.Retorno);
            }

        }

        private void ForCadastro_Load(object sender, EventArgs e)
        {

            string sql = "select * from Clientes where id = " + ID;
            var dr = GlobalTools.Conexao.ExecuteReader(sql);

            txtID.Text = "0";

            //tem dados?
            while (dr.Read())
            {

                txtData.Value = Convert.ToDateTime(dr["data"].ToString());
                txtNome.Text = dr["nome"].ToString();
                txtID.Text = dr["id"].ToString();
                txtEmail.Text = dr["email"].ToString();

            }

            dr.Close();

        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

    }

}
