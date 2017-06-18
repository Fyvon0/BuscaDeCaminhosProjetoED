namespace _16164_16187_Projeto4ED
{
    partial class frmBuscaCaminhos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnManutCidade = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxOrigem = new System.Windows.Forms.ComboBox();
            this.cbxDestino = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbtnRecursao = new System.Windows.Forms.RadioButton();
            this.rdbtnBacktracking = new System.Windows.Forms.RadioButton();
            this.rdbtnDijkstra = new System.Windows.Forms.RadioButton();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtCaminhos = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(181, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 452);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnManutCidade
            // 
            this.btnManutCidade.Location = new System.Drawing.Point(21, 12);
            this.btnManutCidade.Name = "btnManutCidade";
            this.btnManutCidade.Size = new System.Drawing.Size(143, 23);
            this.btnManutCidade.TabIndex = 1;
            this.btnManutCidade.Text = "Manutenção de Cidades";
            this.btnManutCidade.UseVisualStyleBackColor = true;
            this.btnManutCidade.Click += new System.EventHandler(this.btnManutCidade_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.txtCaminhos);
            this.groupBox1.Controls.Add(this.btnPesquisar);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cbxDestino);
            this.groupBox1.Controls.Add(this.cbxOrigem);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 423);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busca de Caminhos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Origem";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Destino";
            // 
            // cbxOrigem
            // 
            this.cbxOrigem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOrigem.FormattingEnabled = true;
            this.cbxOrigem.Location = new System.Drawing.Point(55, 15);
            this.cbxOrigem.Name = "cbxOrigem";
            this.cbxOrigem.Size = new System.Drawing.Size(102, 21);
            this.cbxOrigem.TabIndex = 2;
            // 
            // cbxDestino
            // 
            this.cbxDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDestino.FormattingEnabled = true;
            this.cbxDestino.Location = new System.Drawing.Point(55, 39);
            this.cbxDestino.Name = "cbxDestino";
            this.cbxDestino.Size = new System.Drawing.Size(102, 21);
            this.cbxDestino.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbtnDijkstra);
            this.groupBox2.Controls.Add(this.rdbtnBacktracking);
            this.groupBox2.Controls.Add(this.rdbtnRecursao);
            this.groupBox2.Location = new System.Drawing.Point(9, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(143, 89);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Método";
            // 
            // rdbtnRecursao
            // 
            this.rdbtnRecursao.AutoSize = true;
            this.rdbtnRecursao.Checked = true;
            this.rdbtnRecursao.Location = new System.Drawing.Point(6, 19);
            this.rdbtnRecursao.Name = "rdbtnRecursao";
            this.rdbtnRecursao.Size = new System.Drawing.Size(71, 17);
            this.rdbtnRecursao.TabIndex = 0;
            this.rdbtnRecursao.TabStop = true;
            this.rdbtnRecursao.Text = "Recursão";
            this.rdbtnRecursao.UseVisualStyleBackColor = true;
            // 
            // rdbtnBacktracking
            // 
            this.rdbtnBacktracking.AutoSize = true;
            this.rdbtnBacktracking.Location = new System.Drawing.Point(6, 42);
            this.rdbtnBacktracking.Name = "rdbtnBacktracking";
            this.rdbtnBacktracking.Size = new System.Drawing.Size(88, 17);
            this.rdbtnBacktracking.TabIndex = 1;
            this.rdbtnBacktracking.TabStop = true;
            this.rdbtnBacktracking.Text = "Backtracking";
            this.rdbtnBacktracking.UseVisualStyleBackColor = true;
            // 
            // rdbtnDijkstra
            // 
            this.rdbtnDijkstra.AutoSize = true;
            this.rdbtnDijkstra.Location = new System.Drawing.Point(6, 65);
            this.rdbtnDijkstra.Name = "rdbtnDijkstra";
            this.rdbtnDijkstra.Size = new System.Drawing.Size(60, 17);
            this.rdbtnDijkstra.TabIndex = 2;
            this.rdbtnDijkstra.TabStop = true;
            this.rdbtnDijkstra.Text = "Dijkstra";
            this.rdbtnDijkstra.UseVisualStyleBackColor = true;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(9, 161);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(143, 23);
            this.btnPesquisar.TabIndex = 5;
            this.btnPesquisar.Text = "Achar Caminhos";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtCaminhos
            // 
            this.txtCaminhos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCaminhos.Location = new System.Drawing.Point(9, 190);
            this.txtCaminhos.Multiline = true;
            this.txtCaminhos.Name = "txtCaminhos";
            this.txtCaminhos.Size = new System.Drawing.Size(148, 227);
            this.txtCaminhos.TabIndex = 6;
            // 
            // frmBuscaCaminhos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(689, 476);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnManutCidade);
            this.Controls.Add(this.panel1);
            this.Name = "frmBuscaCaminhos";
            this.Text = "Achar Caminhos Entre Cidades";
            this.Load += new System.EventHandler(this.frmBuscaCaminhos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnManutCidade;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCaminhos;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbtnDijkstra;
        private System.Windows.Forms.RadioButton rdbtnBacktracking;
        private System.Windows.Forms.RadioButton rdbtnRecursao;
        private System.Windows.Forms.ComboBox cbxDestino;
        private System.Windows.Forms.ComboBox cbxOrigem;
    }
}

