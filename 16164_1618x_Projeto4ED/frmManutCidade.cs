using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16164_16187_Projeto4ED
{
    public partial class frmManutCidade : Form
    {
        ArvoreDeBusca<Cidade> arvoreCidades;
        ListaCaminhos listaCaminhos;

        public frmManutCidade()
        {
            InitializeComponent();
        }

        private void frmManutCidade_Load(object sender, EventArgs e)
        {
            FileStream arqCidades = new FileStream("arqCidades.cid", FileMode.OpenOrCreate);
            arvoreCidades = new ArvoreDeBusca<Cidade>();
            NoArvore<Cidade> raizTemp = arvoreCidades.Raiz;
            RegistroCidade regCidade = new RegistroCidade();
            LeituraDaArvore(0, arqCidades.Length / Cidade.TAMANHO_DO_REGISTRO - 1,
                            ref raizTemp, ref regCidade, ref arqCidades); // não deixa passar propriedade como ref
            arqCidades.Close();
            lstCaminhos.HorizontalScrollbar = true;
            arvoreCidades.raiz = raizTemp;
            arvoreCidades.OndeExibir = pnlArvore;

            FileStream arqCaminhos = new FileStream("arqCaminhos.cam", FileMode.OpenOrCreate);
            listaCaminhos = new ListaCaminhos();
            RegistroCaminho regCaminho = new RegistroCaminho();
            for (int i = 0; i < arqCaminhos.Length/Caminho.TAMANHO_DO_REGISTRO; i++)
            {
                Caminho novoCaminho = new Caminho(new Cidade("",0D,0D), new Cidade("",0D,0D), int.MaxValue);
                regCaminho.LerRegistro(arqCaminhos, i, ref novoCaminho);
                listaCaminhos.inserirEmOrdem(novoCaminho);
                lstCaminhos.Items.Add(novoCaminho.ToString());
            }
            arqCaminhos.Close();
            pnlArvore.Invalidate();
        }

        private void LeituraDaArvore(long inicio, long fim, ref NoArvore<Cidade> atual, ref RegistroCidade regCidade, ref FileStream arqCidades)
        {
            if (inicio <= fim)
            {
                int meio = (int)(inicio + fim) / 2;
                Cidade umaCidade = new Cidade("",0D,0D);
                regCidade.LerRegistro(arqCidades, meio, ref umaCidade);
                atual = new NoArvore<Cidade>(umaCidade);
                LeituraDaArvore(inicio, meio - 1, ref atual.esquerdo, ref regCidade, ref arqCidades);
                LeituraDaArvore(meio + 1, fim, ref atual.direito, ref regCidade, ref arqCidades);
                txtCidade.Items.Add(atual.Info.ToString());
                cbxPartida.Items.Add(atual.Info.ToString());
                cbxDestino.Items.Add(atual.Info.ToString());
            }
        }

        private void pnlArvore_Paint(object sender, PaintEventArgs e)
        {
            (sender as Panel).CreateGraphics().Clear((sender as Panel).BackColor);
            if (arvoreCidades != null)
                arvoreCidades.DesenharArvore(true, arvoreCidades.raiz, pnlArvore.Width / 2, 0, Math.PI / 2, Math.PI / 2.5, 200);
        }

        private void btnIncluirCidade_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtCidade.Text))
            {
                MessageBox.Show("Insira o nome da cidade");
                return;
            }

            if (!txtCidade.Items.Contains(txtCidade.Text))
            {
                MessageBox.Show("Por favor, indique a posição da cidade");
                frmMapaCidade MapaCidade = new frmMapaCidade(ref arvoreCidades, ref listaCaminhos);
                MapaCidade.ShowDialog(this);
                arvoreCidades.inserir(new Cidade(txtCidade.Text, MapaCidade.RazaoX, MapaCidade.RazaoY));
                txtCidade.Items.Add(txtCidade.Text);
                cbxDestino.Items.Add(txtCidade.Text);
                cbxPartida.Items.Add(txtCidade.Text);
                MessageBox.Show("Cidade incluída com sucesso");
            }
            else
                MessageBox.Show("A cidade indicada já estava cadastrada");

            pnlArvore.Invalidate();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (arvoreCidades.ApagarNo(new Cidade(txtCidade.Text,0D,0D)))
            {
                listaCaminhos.ExcluirCidade(txtCidade.Text);
                MessageBox.Show("Cidade excluída com sucesso");
                txtCidade.Items.Remove(txtCidade.Text);
                cbxDestino.Items.Remove(txtCidade.Text);
                cbxPartida.Items.Remove(txtCidade.Text);
                lstCaminhos.Items.Clear();
                listaCaminhos.IniciarPercursoSequencial();
                while (listaCaminhos.PodePercorrer())
                    lstCaminhos.Items.Add(listaCaminhos.Atual.Info.ToString());
            }
            else
                MessageBox.Show("Não foi possível localizar a cidade escolhida");

            pnlArvore.Invalidate();
        }

        int posicao = 0;

        private void frmManutCidade_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileStream arqCidades = new FileStream("arqCidades.cid", FileMode.Truncate);
            RegistroCidade regCidade = new RegistroCidade();
            GravarArquivoCidade(ref arqCidades, ref arvoreCidades.raiz, ref regCidade);
            arqCidades.Close();
            FileStream arqCaminhos = new FileStream("arqCaminhos.cam", FileMode.Truncate);
            RegistroCaminho regCaminho = new RegistroCaminho();
            int indice = 0;
            listaCaminhos.IniciarPercursoSequencial();
            while (listaCaminhos.PodePercorrer())
            {
                regCaminho.GravarRegistro(arqCaminhos, indice, listaCaminhos.Atual.Info);
                indice++;
            }
            arqCaminhos.Close();

            DialogResult = DialogResult.OK;
        }

        private void GravarArquivoCidade (ref FileStream f, ref NoArvore<Cidade> atual, ref RegistroCidade registro)
        {
            if (atual != null)
            {
                GravarArquivoCidade(ref f, ref atual.esquerdo, ref registro);
                registro.GravarRegistro(f, posicao++, atual.Info);
                GravarArquivoCidade(ref f, ref atual.direito, ref registro);
            }
        }

        private void btnIncluirCaminho_Click(object sender, EventArgs e)
        {
            if (cbxDestino.SelectedIndex < 0 || cbxPartida.SelectedIndex < 0 || numDistancia.Value <= 0)
            {
                MessageBox.Show("Por favor, insira os dados corretamente");
                return;
            }

            if (cbxDestino.Text == cbxPartida.Text)
            {
                MessageBox.Show("A cidade de partida não pode ser igual à cidade de destino");
                return;
            }

            if (listaCaminhos.inserirEmOrdem(new Caminho(cbxPartida.Text, cbxDestino.Text, (int)numDistancia.Value)))
            {
                MessageBox.Show("Caminho adicionado com sucesso =D");
                lstCaminhos.Items.Add(new Caminho(new Cidade(cbxPartida.Text,0D,0D), new Cidade(cbxDestino.Text,0D,0D), (int)numDistancia.Value).ToString());
            }
            else
                MessageBox.Show("Já existe um caminho entre essas duas cidades");
        }

        private void btnExcluirCaminho_Click(object sender, EventArgs e)
        {
            if (cbxDestino.SelectedIndex < 0 || cbxPartida.SelectedIndex < 0 || numDistancia.Value <= 0)
            {
                MessageBox.Show("Por favor, insira os dados corretamente");
                return;
            }

            if (cbxDestino.Text == cbxPartida.Text)
            {
                MessageBox.Show("A cidade de partida não pode ser igual à cidade de destino");
                return;
            }

            if (listaCaminhos.removerDado(new Caminho(cbxPartida.Text, cbxDestino.Text, (int)numDistancia.Value)))
            {
                MessageBox.Show("Caminho removido com sucesso");
                lstCaminhos.Items.Clear();
                listaCaminhos.IniciarPercursoSequencial();
                while (listaCaminhos.PodePercorrer())
                    lstCaminhos.Items.Add(listaCaminhos.Atual.Info);
            }
            else
                MessageBox.Show("Não foi possível encontrar o caminho especificado");
        }
    }
}