namespace ADO.NET_CRUD
{
    partial class ForPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpOrigem = new System.Windows.Forms.GroupBox();
            this.txtOrigemSenha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOrigemUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOrigemDatabase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrigemServidor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpDestino = new System.Windows.Forms.GroupBox();
            this.txtDestinoSenha = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDestinoUsuario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDestinoDatabase = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDestinoServidor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdCarregarEmpresas = new System.Windows.Forms.Button();
            this.lstEmpresas = new System.Windows.Forms.ListView();
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCnpj = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdImportar = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpOrigem.SuspendLayout();
            this.grpDestino.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpOrigem
            // 
            this.grpOrigem.Controls.Add(this.txtOrigemSenha);
            this.grpOrigem.Controls.Add(this.label4);
            this.grpOrigem.Controls.Add(this.txtOrigemUsuario);
            this.grpOrigem.Controls.Add(this.label3);
            this.grpOrigem.Controls.Add(this.txtOrigemDatabase);
            this.grpOrigem.Controls.Add(this.label2);
            this.grpOrigem.Controls.Add(this.txtOrigemServidor);
            this.grpOrigem.Controls.Add(this.label1);
            this.grpOrigem.Location = new System.Drawing.Point(12, 12);
            this.grpOrigem.Name = "grpOrigem";
            this.grpOrigem.Size = new System.Drawing.Size(448, 141);
            this.grpOrigem.TabIndex = 0;
            this.grpOrigem.TabStop = false;
            this.grpOrigem.Text = "Banco de Origem";
            // ... trimmed positions
            this.txtOrigemSenha.Location = new System.Drawing.Point(94, 102); this.txtOrigemSenha.Name = "txtOrigemSenha"; this.txtOrigemSenha.PasswordChar='*'; this.txtOrigemSenha.Size = new System.Drawing.Size(337, 20);
            this.label4.AutoSize = true; this.label4.Location = new System.Drawing.Point(19, 105); this.label4.Text = "Senha";
            this.txtOrigemUsuario.Location = new System.Drawing.Point(94, 76); this.txtOrigemUsuario.Size = new System.Drawing.Size(337, 20);
            this.label3.AutoSize = true; this.label3.Location = new System.Drawing.Point(19, 79); this.label3.Text = "Usuário";
            this.txtOrigemDatabase.Location = new System.Drawing.Point(94, 50); this.txtOrigemDatabase.Size = new System.Drawing.Size(337, 20);
            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(19, 53); this.label2.Text = "Database";
            this.txtOrigemServidor.Location = new System.Drawing.Point(94, 24); this.txtOrigemServidor.Size = new System.Drawing.Size(337, 20);
            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(19, 27); this.label1.Text = "Servidor";

            this.grpDestino.Controls.Add(this.txtDestinoSenha); this.grpDestino.Controls.Add(this.label5); this.grpDestino.Controls.Add(this.txtDestinoUsuario); this.grpDestino.Controls.Add(this.label6); this.grpDestino.Controls.Add(this.txtDestinoDatabase); this.grpDestino.Controls.Add(this.label7); this.grpDestino.Controls.Add(this.txtDestinoServidor); this.grpDestino.Controls.Add(this.label8);
            this.grpDestino.Location = new System.Drawing.Point(477, 12); this.grpDestino.Name = "grpDestino"; this.grpDestino.Size = new System.Drawing.Size(448, 141); this.grpDestino.TabStop=false; this.grpDestino.Text = "Banco de Destino";
            this.txtDestinoSenha.Location = new System.Drawing.Point(94, 102); this.txtDestinoSenha.Name="txtDestinoSenha"; this.txtDestinoSenha.PasswordChar='*'; this.txtDestinoSenha.Size = new System.Drawing.Size(337, 20);
            this.label5.AutoSize=true; this.label5.Location = new System.Drawing.Point(19,105); this.label5.Text="Senha";
            this.txtDestinoUsuario.Location = new System.Drawing.Point(94,76); this.txtDestinoUsuario.Size = new System.Drawing.Size(337,20);
            this.label6.AutoSize=true; this.label6.Location = new System.Drawing.Point(19,79); this.label6.Text="Usuário";
            this.txtDestinoDatabase.Location = new System.Drawing.Point(94,50); this.txtDestinoDatabase.Size = new System.Drawing.Size(337,20);
            this.label7.AutoSize=true; this.label7.Location = new System.Drawing.Point(19,53); this.label7.Text="Database";
            this.txtDestinoServidor.Location = new System.Drawing.Point(94,24); this.txtDestinoServidor.Size = new System.Drawing.Size(337,20);
            this.label8.AutoSize=true; this.label8.Location = new System.Drawing.Point(19,27); this.label8.Text="Servidor";

            this.cmdCarregarEmpresas.Location = new System.Drawing.Point(12, 168); this.cmdCarregarEmpresas.Size = new System.Drawing.Size(173, 29); this.cmdCarregarEmpresas.Text = "Carregar Empresas"; this.cmdCarregarEmpresas.Click += new System.EventHandler(this.cmdCarregarEmpresas_Click);
            this.cmdImportar.Location = new System.Drawing.Point(752, 168); this.cmdImportar.Size = new System.Drawing.Size(173, 29); this.cmdImportar.Text = "Importar Selecionadas"; this.cmdImportar.Click += new System.EventHandler(this.cmdImportar_Click);

            this.lstEmpresas.CheckBoxes = true; this.lstEmpresas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.colId, this.colCnpj, this.colNome }); this.lstEmpresas.FullRowSelect=true; this.lstEmpresas.GridLines=true; this.lstEmpresas.Location = new System.Drawing.Point(12, 203); this.lstEmpresas.Size = new System.Drawing.Size(913, 297); this.lstEmpresas.View = System.Windows.Forms.View.Details;
            this.colId.Text = "ID"; this.colId.Width = 80; this.colCnpj.Text = "CNPJ"; this.colCnpj.Width = 180; this.colNome.Text = "Nome"; this.colNome.Width = 620;
            this.lblStatus.AutoSize=true; this.lblStatus.Location = new System.Drawing.Point(12,510); this.lblStatus.Size = new System.Drawing.Size(96,13); this.lblStatus.Text="Pronto para uso.";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font; this.ClientSize = new System.Drawing.Size(940, 534); this.Controls.Add(this.lblStatus); this.Controls.Add(this.cmdImportar); this.Controls.Add(this.lstEmpresas); this.Controls.Add(this.cmdCarregarEmpresas); this.Controls.Add(this.grpDestino); this.Controls.Add(this.grpOrigem); this.Name = "ForPrincipal"; this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; this.Text = "Importador ADODB SQL Server"; this.Load += new System.EventHandler(this.ForPrincipal_Load);
            this.grpOrigem.ResumeLayout(false); this.grpOrigem.PerformLayout(); this.grpDestino.ResumeLayout(false); this.grpDestino.PerformLayout(); this.ResumeLayout(false); this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpOrigem;
        private System.Windows.Forms.TextBox txtOrigemSenha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOrigemUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOrigemDatabase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrigemServidor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpDestino;
        private System.Windows.Forms.TextBox txtDestinoSenha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDestinoUsuario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDestinoDatabase;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDestinoServidor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cmdCarregarEmpresas;
        private System.Windows.Forms.ListView lstEmpresas;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colCnpj;
        private System.Windows.Forms.ColumnHeader colNome;
        private System.Windows.Forms.Button cmdImportar;
        private System.Windows.Forms.Label lblStatus;
    }
}
