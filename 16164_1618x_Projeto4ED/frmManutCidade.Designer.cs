namespace _16164_16187_Projeto4ED
{
    partial class frmManutCidade
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.txtCidade = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnIncluirCidade = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnIncluirCaminho = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numDistancia = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxDestino = new System.Windows.Forms.ComboBox();
            this.cbxPartida = new System.Windows.Forms.ComboBox();
            this.pnlArvore = new System.Windows.Forms.Panel();
            this.lstCaminhos = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExcluirCaminho = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDistancia)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnExcluir);
            this.groupBox1.Controls.Add(this.txtCidade);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnIncluirCidade);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cidades";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(167, 31);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(49, 21);
            this.btnExcluir.TabIndex = 10;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // txtCidade
            // 
            this.txtCidade.FormattingEnabled = true;
            this.txtCidade.Location = new System.Drawing.Point(6, 31);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(100, 21);
            this.txtCidade.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nome";
            // 
            // btnIncluirCidade
            // 
            this.btnIncluirCidade.Location = new System.Drawing.Point(112, 31);
            this.btnIncluirCidade.Name = "btnIncluirCidade";
            this.btnIncluirCidade.Size = new System.Drawing.Size(49, 21);
            this.btnIncluirCidade.TabIndex = 7;
            this.btnIncluirCidade.Text = "Incluir";
            this.btnIncluirCidade.UseVisualStyleBackColor = true;
            this.btnIncluirCidade.Click += new System.EventHandler(this.btnIncluirCidade_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnExcluirCaminho);
            this.groupBox2.Controls.Add(this.btnIncluirCaminho);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numDistancia);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbxDestino);
            this.groupBox2.Controls.Add(this.cbxPartida);
            this.groupBox2.Location = new System.Drawing.Point(240, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 60);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Caminhos";
            // 
            // btnIncluirCaminho
            // 
            this.btnIncluirCaminho.Location = new System.Drawing.Point(371, 32);
            this.btnIncluirCaminho.Name = "btnIncluirCaminho";
            this.btnIncluirCaminho.Size = new System.Drawing.Size(49, 20);
            this.btnIncluirCaminho.TabIndex = 6;
            this.btnIncluirCaminho.Text = "Incluir";
            this.btnIncluirCaminho.UseVisualStyleBackColor = true;
            this.btnIncluirCaminho.Click += new System.EventHandler(this.btnIncluirCaminho_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Destino";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Partida";
            // 
            // numDistancia
            // 
            this.numDistancia.Location = new System.Drawing.Point(308, 32);
            this.numDistancia.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numDistancia.Name = "numDistancia";
            this.numDistancia.Size = new System.Drawing.Size(57, 20);
            this.numDistancia.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Distância";
            // 
            // cbxDestino
            // 
            this.cbxDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDestino.FormattingEnabled = true;
            this.cbxDestino.Location = new System.Drawing.Point(133, 32);
            this.cbxDestino.Name = "cbxDestino";
            this.cbxDestino.Size = new System.Drawing.Size(121, 21);
            this.cbxDestino.TabIndex = 1;
            // 
            // cbxPartida
            // 
            this.cbxPartida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPartida.FormattingEnabled = true;
            this.cbxPartida.Location = new System.Drawing.Point(6, 32);
            this.cbxPartida.Name = "cbxPartida";
            this.cbxPartida.Size = new System.Drawing.Size(121, 21);
            this.cbxPartida.TabIndex = 0;
            // 
            // pnlArvore
            // 
            this.pnlArvore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlArvore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlArvore.Location = new System.Drawing.Point(9, 78);
            this.pnlArvore.Name = "pnlArvore";
            this.pnlArvore.Size = new System.Drawing.Size(716, 382);
            this.pnlArvore.TabIndex = 2;
            this.pnlArvore.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlArvore_Paint);
            // 
            // lstCaminhos
            // 
            this.lstCaminhos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCaminhos.FormattingEnabled = true;
            this.lstCaminhos.Location = new System.Drawing.Point(734, 28);
            this.lstCaminhos.Name = "lstCaminhos";
            this.lstCaminhos.Size = new System.Drawing.Size(213, 420);
            this.lstCaminhos.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(731, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Caminhos";
            // 
            // btnExcluirCaminho
            // 
            this.btnExcluirCaminho.Location = new System.Drawing.Point(426, 32);
            this.btnExcluirCaminho.Name = "btnExcluirCaminho";
            this.btnExcluirCaminho.Size = new System.Drawing.Size(49, 20);
            this.btnExcluirCaminho.TabIndex = 7;
            this.btnExcluirCaminho.Text = "Excluir";
            this.btnExcluirCaminho.UseVisualStyleBackColor = true;
            this.btnExcluirCaminho.Click += new System.EventHandler(this.btnExcluirCaminho_Click);
            // 
            // frmManutCidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 472);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstCaminhos);
            this.Controls.Add(this.pnlArvore);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmManutCidade";
            this.Text = "Manutenção de Cidades e Caminhos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmManutCidade_FormClosing);
            this.Load += new System.EventHandler(this.frmManutCidade_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDistancia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnIncluirCaminho;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numDistancia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxDestino;
        private System.Windows.Forms.ComboBox cbxPartida;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnIncluirCidade;
        private System.Windows.Forms.Panel pnlArvore;
        private System.Windows.Forms.ComboBox txtCidade;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.ListBox lstCaminhos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnExcluirCaminho;
    }
}