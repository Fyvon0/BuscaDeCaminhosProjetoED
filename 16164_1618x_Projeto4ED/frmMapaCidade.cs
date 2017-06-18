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

        /// <summary>
        /// Inicializa as variáveis do formulário e monta o grafo a partir da árvore de cidades recebida
        /// </summary>
        /// <param name="cidades">Árvore das cidades que serão desenhadas no mapa</param>
        public frmMapaCidade(ref ArvoreDeBusca<Cidade> cidades)
        {
            InitializeComponent();
            grafoMapa = new GrafoCidades(null);
            PercorrerArvore(ref cidades.raiz);
            pnlMapa.Invalidate();
        }

        /// <summary>
        /// Percorre a árvore e adiciona seus nós no grafo
        /// </summary>
        /// <param name="atual">Nó atual da árvore</param>
        private void PercorrerArvore (ref NoArvore<Cidade> atual)
        {
            if (atual != null)
            {
                PercorrerArvore(ref atual.esquerdo);
                grafoMapa.NovoVertice(atual.Info);
                PercorrerArvore(ref atual.direito);
            }    
        }

        private void pnlMapa_MouseDown(object sender, MouseEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Escreve a posição atual do mouse e sua razão
        /// </summary>
        /// <param name="sender">Objeto que gerou o evento</param>
        /// <param name="e">Parâmetros do evento</param>
        private void pnlMapa_MouseMove(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            lblPosicoes.Text = x + " x " + y;
            lblRazoes.Text = x / (Double)pnlMapa.Width + " x " + y / (Double)pnlMapa.Height;
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
