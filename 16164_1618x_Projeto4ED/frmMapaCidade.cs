using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16164_16187_Projeto4ED
{
    public partial class frmMapaCidade : Form
    {
        private int x, y;
        private GrafoCidades grafoMapa;
        //private int indice;
        //private Cidade[] vetorCidades;

        public frmMapaCidade(ref ArvoreDeBusca<Cidade> cidades, ref ListaCaminhos caminhos)
        {
            InitializeComponent();
            grafoMapa = new GrafoCidades(null);
            //vetorCidades = new Cidade[cidades.QuantosNos];
            //indice = 0;
            PercorrerArvore(ref cidades.raiz);
            pnlMapa.Invalidate();
        }
        private void PercorrerArvore (ref NoArvore<Cidade> atual)
        {
            if (atual != null)
            {
                PercorrerArvore(ref atual.esquerdo);
                //vetorCidades[indice] = atual.Info;
                //indice++;
                grafoMapa.NovoVertice(atual.Info.Nome, atual.Info);
                PercorrerArvore(ref atual.direito);
            }    
        }

        private void pnlMapa_MouseDown(object sender, MouseEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void pnlMapa_MouseMove(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            lblPosicoes.Text = x + "x" + y;
            lblRazoes.Text = x / (Double)pnlMapa.Width + "x" + y / (Double)pnlMapa.Height;
        }

        public Double RazaoX
        {
            get { return x / (Double)pnlMapa.Width; }
        }

        private void pnlMapa_Paint(object sender, PaintEventArgs e)
        {
            grafoMapa.ExibirCidades((sender as Panel));
        }

        public Double RazaoY
        {
            get { return y / (Double)pnlMapa.Height; }
        }
    }
}
