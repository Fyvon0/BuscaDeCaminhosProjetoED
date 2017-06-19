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
    public partial class frmBuscaCaminhos : Form
    {
        GrafoCidades grafoCaminhos;
        String[] cidades;

        public frmBuscaCaminhos()
        {
            InitializeComponent();
        }

        private void frmBuscaCaminhos_Load(object sender, EventArgs e)
        {
            grafoCaminhos = new GrafoCidades(null);
            cidades = new String[GrafoCidades.NUM_VERTICES];

            FileStream arqCidades = new FileStream("arqCidades.cid", FileMode.OpenOrCreate); // abre o arquivo, criando-o se não existir
            RegistroCidade regCidade = new RegistroCidade();
            for (int i = 0; i < arqCidades.Length / Cidade.TAMANHO_DO_REGISTRO; i++) //Enquanto houver registros para ler, o faz
            {
                Cidade novaCidade = new Cidade("", 0D, 0D);
                regCidade.LerRegistro(arqCidades, i, ref novaCidade); // lê o registro e o armazena em novaCidade
                cidades[i] = novaCidade.ToString();
                cbxDestino.Items.Add(novaCidade.ToString());
                cbxOrigem.Items.Add(novaCidade.ToString());
                grafoCaminhos.NovoVertice(novaCidade);
            }
            arqCidades.Close(); // fecha o arquivo de cidades

            FileStream arqCaminhos = new FileStream("arqCaminhos.cam", FileMode.OpenOrCreate);// abre o arquivo, criando-o se não existir
            RegistroCaminho regCaminho = new RegistroCaminho();
            for (int i = 0; i < arqCaminhos.Length / Caminho.TAMANHO_DO_REGISTRO; i++) //Enquanto houver registros para ler, o faz
            {
                Caminho novoCaminho = new Caminho(new Cidade("", 0D, 0D), new Cidade("", 0D, 0D), int.MaxValue);
                regCaminho.LerRegistro(arqCaminhos, i, ref novoCaminho); // lê o registro e o armazena em novoCaminho
                int cid1 = IndiceDe(novoCaminho.Saida.ToString());
                int cid2 = IndiceDe(novoCaminho.Destino.ToString());
                if (cid1 > 0 && cid2 > 0) // se as duas cidades existirem
                    grafoCaminhos.NovaAresta(cid1, cid2, novoCaminho.Distancia); // cria uma novas aresta entre essa cidades
            }
            arqCaminhos.Close(); //fecha o arquivo de caminhos

            panel1.Invalidate();
        }

        /// <summary>
        /// Retorna o indíce da cidade no vetor de cidades
        /// </summary>
        /// <param name="nomeDaCidade">Nome da cidade a ser procurada</param>
        /// <returns>O indíce da cidade recebida no vetor ou -1 se ela não estiver cadastrada</returns>
        private int IndiceDe(String nomeDaCidade)
        {
            nomeDaCidade = nomeDaCidade.Trim();
            for (int i = 0; i < cidades.Length; i++)
                if (cidades[i] == nomeDaCidade)
                    return i;

            return -1;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            grafoCaminhos.ExibirCaminhos(sender as Panel);
        }

        private void btnManutCidade_Click(object sender, EventArgs e)
        {
            frmManutCidade ManutCidade = new frmManutCidade(); // chama o formulário de manutenção de cidades
            ManutCidade.ShowDialog(this);

            grafoCaminhos = new GrafoCidades(null);
            cidades = new String[GrafoCidades.NUM_VERTICES];
            cbxDestino.Items.Clear();
            cbxOrigem.Items.Clear();

            // Lê os arquivos novamente para atualizar as alterações
            FileStream arqCidades = new FileStream("arqCidades.cid", FileMode.OpenOrCreate);
            RegistroCidade regCidade = new RegistroCidade();
            for (int i = 0; i < arqCidades.Length / Cidade.TAMANHO_DO_REGISTRO; i++)
            {
                Cidade novaCidade = new Cidade("", 0D, 0D);
                regCidade.LerRegistro(arqCidades, i, ref novaCidade);
                cidades[i] = novaCidade.ToString();
                cbxDestino.Items.Add(novaCidade.ToString());
                cbxOrigem.Items.Add(novaCidade.ToString());
                grafoCaminhos.NovoVertice(novaCidade);
            }
            arqCidades.Close();

            FileStream arqCaminhos = new FileStream("arqCaminhos.cam", FileMode.OpenOrCreate);
            RegistroCaminho regCaminho = new RegistroCaminho();
            for (int i = 0; i < arqCaminhos.Length / Caminho.TAMANHO_DO_REGISTRO; i++)
            {
                Caminho novoCaminho = new Caminho(new Cidade("", 0D, 0D), new Cidade("", 0D, 0D), int.MaxValue);
                regCaminho.LerRegistro(arqCaminhos, i, ref novoCaminho);
                int cid1 = IndiceDe(novoCaminho.Saida.ToString());
                int cid2 = IndiceDe(novoCaminho.Destino.ToString());
                if (cid1 > 0 && cid2 > 0)
                    grafoCaminhos.NovaAresta(cid1, cid2, novoCaminho.Distancia);
            }
            arqCaminhos.Close();

            panel1.Invalidate(); // atualiza o panel1
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (cbxDestino.SelectedIndex < 0 || cbxOrigem.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, escolha as duas cidades");
                return;
            }

            if (cbxDestino.Text == cbxOrigem.Text)
            {
                MessageBox.Show("As cidade de origem e de destino coincidem");
                return;
            }

            txtCaminhos.Clear();
            Stack<Movimento> movs = null;
            if (rdbtnBacktracking.Checked)
                movs = grafoCaminhos.BacktrackingMelhorCaminho(cbxOrigem.Text, cbxDestino.Text); // obtém o melhor caminho por backtracking
            //else if (rdbtnDijkstra.Checked)
                
            else if (rdbtnRecursao.Checked)
                movs = grafoCaminhos.RecursaoMelhorCaminho(cbxOrigem.Text, cbxDestino.Text);

            if (movs != null && movs.Count > 0) // se houver caminho entre as duas cidades
            {
                Stack<Movimento> caminhosOrdenados = new Stack<Movimento>();
                while (movs.Count > 0) // inverte a pilha de resultados
                    caminhosOrdenados.Push(movs.Pop());
                Movimento mov = null;
                int distancia = 0;
                while (caminhosOrdenados.Count > 0)
                {
                    mov = caminhosOrdenados.Pop();
                    txtCaminhos.AppendText(cidades[mov.getCidade()] + " - ");
                    distancia += grafoCaminhos.ConexaoDiretaEntre(cidades[mov.getCidade()], cidades[mov.getSaida()]);
                }
                txtCaminhos.AppendText(cidades[mov.getSaida()]);
                txtCaminhos.AppendText(": " + distancia + "km");
            }
            else
                MessageBox.Show("Não foi possível encontrar um caminho entre as cidades especificadas");
        }
    }
}
