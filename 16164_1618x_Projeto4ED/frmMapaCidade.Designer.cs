namespace _16164_16187_Projeto4ED
{
    partial class frmMapaCidade
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblRazoes = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPosicoes = new System.Windows.Forms.Label();
            this.pnlMapa = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 341);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 21);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.lblRazoes);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(150, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(221, 21);
            this.panel3.TabIndex = 1;
            // 
            // lblRazoes
            // 
            this.lblRazoes.AutoSize = true;
            this.lblRazoes.Location = new System.Drawing.Point(4, 3);
            this.lblRazoes.Name = "lblRazoes";
            this.lblRazoes.Size = new System.Drawing.Size(35, 13);
            this.lblRazoes.TabIndex = 1;
            this.lblRazoes.Text = "label2";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblPosicoes);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 21);
            this.panel2.TabIndex = 0;
            // 
            // lblPosicoes
            // 
            this.lblPosicoes.AutoSize = true;
            this.lblPosicoes.Location = new System.Drawing.Point(1, 3);
            this.lblPosicoes.Name = "lblPosicoes";
            this.lblPosicoes.Size = new System.Drawing.Size(35, 13);
            this.lblPosicoes.TabIndex = 0;
            this.lblPosicoes.Text = "label1";
            // 
            // pnlMapa
            // 
            this.pnlMapa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMapa.Location = new System.Drawing.Point(0, 0);
            this.pnlMapa.Name = "pnlMapa";
            this.pnlMapa.Size = new System.Drawing.Size(371, 341);
            this.pnlMapa.TabIndex = 1;
            this.pnlMapa.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMapa_Paint);
            this.pnlMapa.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMapa_MouseDown);
            this.pnlMapa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlMapa_MouseMove);
            // 
            // frmMapaCidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 362);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMapa);
            this.Controls.Add(this.panel1);
            this.Name = "frmMapaCidade";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Mapa das Cidades";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblRazoes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblPosicoes;
        private System.Windows.Forms.Panel pnlMapa;
    }
}