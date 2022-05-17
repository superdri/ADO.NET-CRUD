
namespace ADO.NET_CRUD
{
    partial class ForPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdConectar = new System.Windows.Forms.Button();
            this.txtSer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.cmdCriarTabela = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.cmdListar = new System.Windows.Forms.Button();
            this.cmdNovo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdConectar
            // 
            this.cmdConectar.Location = new System.Drawing.Point(90, 125);
            this.cmdConectar.Name = "cmdConectar";
            this.cmdConectar.Size = new System.Drawing.Size(75, 23);
            this.cmdConectar.TabIndex = 0;
            this.cmdConectar.Text = "Conectar";
            this.cmdConectar.UseVisualStyleBackColor = true;
            this.cmdConectar.Click += new System.EventHandler(this.cmdConectar_Click);
            // 
            // txtSer
            // 
            this.txtSer.Location = new System.Drawing.Point(90, 12);
            this.txtSer.Name = "txtSer";
            this.txtSer.Size = new System.Drawing.Size(223, 20);
            this.txtSer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "SERVIDOR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "DATABASE";
            // 
            // txtBan
            // 
            this.txtBan.Location = new System.Drawing.Point(90, 38);
            this.txtBan.Name = "txtBan";
            this.txtBan.Size = new System.Drawing.Size(223, 20);
            this.txtBan.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "USUARIO";
            // 
            // txtUsu
            // 
            this.txtUsu.Location = new System.Drawing.Point(90, 64);
            this.txtUsu.Name = "txtUsu";
            this.txtUsu.Size = new System.Drawing.Size(223, 20);
            this.txtUsu.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "SENHA";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(90, 90);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(223, 20);
            this.txtPwd.TabIndex = 7;
            // 
            // cmdCriarTabela
            // 
            this.cmdCriarTabela.Enabled = false;
            this.cmdCriarTabela.Location = new System.Drawing.Point(171, 125);
            this.cmdCriarTabela.Name = "cmdCriarTabela";
            this.cmdCriarTabela.Size = new System.Drawing.Size(75, 23);
            this.cmdCriarTabela.TabIndex = 10;
            this.cmdCriarTabela.Text = "Criar Tabela";
            this.cmdCriarTabela.UseVisualStyleBackColor = true;
            this.cmdCriarTabela.Click += new System.EventHandler(this.cmdCriarTabela_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(90, 159);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(651, 279);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentClick);
            // 
            // cmdListar
            // 
            this.cmdListar.Enabled = false;
            this.cmdListar.Location = new System.Drawing.Point(252, 125);
            this.cmdListar.Name = "cmdListar";
            this.cmdListar.Size = new System.Drawing.Size(75, 23);
            this.cmdListar.TabIndex = 11;
            this.cmdListar.Text = "Listar";
            this.cmdListar.UseVisualStyleBackColor = true;
            this.cmdListar.Click += new System.EventHandler(this.cmdListar_Click);
            // 
            // cmdNovo
            // 
            this.cmdNovo.Enabled = false;
            this.cmdNovo.Location = new System.Drawing.Point(333, 125);
            this.cmdNovo.Name = "cmdNovo";
            this.cmdNovo.Size = new System.Drawing.Size(75, 23);
            this.cmdNovo.TabIndex = 12;
            this.cmdNovo.Text = "Novo";
            this.cmdNovo.UseVisualStyleBackColor = true;
            this.cmdNovo.Click += new System.EventHandler(this.cmdNovo_Click);
            // 
            // ForPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 450);
            this.Controls.Add(this.cmdNovo);
            this.Controls.Add(this.cmdListar);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.cmdCriarTabela);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUsu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSer);
            this.Controls.Add(this.cmdConectar);
            this.Name = "ForPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdConectar;
        private System.Windows.Forms.TextBox txtSer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button cmdCriarTabela;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button cmdListar;
        private System.Windows.Forms.Button cmdNovo;
    }
}

