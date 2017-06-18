using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;   /// para acessar Panel
using System.Drawing;
using System.Threading.Tasks;

namespace _16164_16187_Projeto4ED
{
    class ArvoreBinaria<Dado> where Dado : IComparable<Dado>
    {
        private NoArvore<Dado> raiz, atual, antecessor;

        public Panel painelArvore;

        public Panel OndeExibir
        {
            get { return painelArvore; }
            set { painelArvore = value; }
        }

        public ArvoreBinaria()
        {
            raiz = atual = antecessor = null;
        }

        public NoArvore<Dado> Raiz
        {
            get { return raiz; }
            set { raiz = value; }
        }
        public NoArvore<Dado> Atual
        {
            get { return atual; }
            set { atual = value; }
        }
        public NoArvore<Dado> Antecessor
        {
            get { return antecessor; }
            set { antecessor = value; }
        }

        public String InOrdem  // propriedade- gera a string do percurso in-ordem da árvore
        {
            get { return FazInOrdem(raiz); }
        }

        public String PreOrdem  // propriedade- gera string do percurso pre-ordem da árvore
        {
            get { return FazPreOrdem(raiz); }
        }

        public String PosOrdem  // propriedade- gera string do percurso pos-ordem da árvore
        {
            get { return FazPosOrdem(raiz); }
        }

        private String FazInOrdem(NoArvore<Dado> r)
        {
            if (r == null)
                return "";  // retorna cadeia vazia
            else
            {
                return FazInOrdem(r.esquerdo) +
                           " " + r.Info.ToString() + " " +
                           FazInOrdem(r.direito);
            }
        }

        private String FazPreOrdem(NoArvore<Dado> r)
        {
            if (r == null)
                return "";  // retorna cadeia vazia
            else
            {
                return
                          r.Info.ToString() +
                          " " + FazPreOrdem(r.esquerdo) + " " +
                           FazPreOrdem(r.direito);
            }
        }

        private String FazPosOrdem(NoArvore<Dado> r)
        {
            if (r == null)
                return "";  // retorna cadeia vazia
            else
            {
                return FazPosOrdem(r.esquerdo) + " " +
                           FazPosOrdem(r.direito) +
                           " " + r.Info.ToString();
            }
        }

        private bool existe(NoArvore<Dado> local, Dado procurado)
        {
            if (local == null)
                return false;
            else
              if (local.Info.CompareTo(procurado) == 0)
            {
                Atual = local;
                return true;
            }
            else
            {
                Antecessor = local;
                if (procurado.CompareTo(local.Info) < 0)
                    return existe(local.Esquerdo, procurado); // Desloca apontador na 
            	else                						  // próxima instância do 
	                return existe(local.Direito, procurado);  // método
            }
        }

        public bool existe(Dado procurado)
        {
            return existe(this.Raiz, procurado);
        }


        public bool haDado(Dado procurado)
        {
            antecessor = null;
            atual = Raiz;
            while (atual != null)
            {
                if (atual.Info.CompareTo(procurado) == 0)
                    return true;
                else
                {
                    antecessor = atual;
                    if (procurado.CompareTo(atual.Info) < 0)
                        atual = atual.Esquerdo;     // Desloca à esquerda
                    else
                        atual = atual.Direito;      // Desloca à direita
                }
            }
            return false;       // Se atual == null, a chave não existe
        }

        public void incluirComRecursao(ref NoArvore<Dado> atual, Dado dadoLido)
        {
            if (atual == null)
            {
                atual = new NoArvore<Dado>(dadoLido);
            }
            else
            {
                if (dadoLido.CompareTo(atual.Info) == 0)
                    throw new Exception("Inclusão repetida");
                if (dadoLido.CompareTo(atual.Info) < 0)  // novo < atual
                    incluirComRecursao(ref atual.esquerdo, dadoLido);
                else
                    incluirComRecursao(ref atual.direito, dadoLido);
            }
        }

        public void incluirComRecursao(Dado dadoLido)
        {
            incluirComRecursao(ref raiz, dadoLido);
        }

        public bool incluirSemRecursao(Dado dadoLido)
        {
          if (haDado(dadoLido))
             return false;

            // aqui, atual vale null; significa que a árvore está vazia
            // ou que não encontramos o dadoLido e antecessor aponta seu
            // pai

          NoArvore<Dado> novoNo = new NoArvore<Dado>(dadoLido);
          if (raiz == null)
              raiz = novoNo;
          else
            if (dadoLido.CompareTo(antecessor.Info) < 0)
              antecessor.esquerdo = novoNo;
          else
              antecessor.direito = novoNo;

          return true;
        }

        public void inserir(Dado novosDados)
        {
            bool achou = false, fim = false;
            NoArvore<Dado> novoNo = new NoArvore<Dado>(novosDados);
            if (raiz == null)         // árvore vazia
                raiz = novoNo;
            else                         // árvore não-vazia
            {
                antecessor = null;
                atual = raiz;
                while (!achou && !fim)
                {
                    antecessor = atual;
                    if (novosDados.CompareTo(atual.Info) < 0)
                    {
                        atual = atual.esquerdo;
                        if (atual == null)
                        {
                            antecessor.esquerdo = novoNo;	// liga novo nó com o seu pai
                            fim = true;
                        }
                    }
                    else
                        if (novosDados.CompareTo(atual.Info) == 0)
                        achou = true;  // pode-se disparar uma exceção neste caso
                    else
                    {
                        atual = atual.direito;
                        if (atual == null)
                        {
                            antecessor.direito = novoNo;
                            fim = true;
                        }
                    }
                }
            }
        }

        public int AlturaArvore(NoArvore<Dado> atual, ref bool balanceada)
        {
            int alturaDireita, alturaEsquerda, result;
            if (atual != null && balanceada)
            {
                alturaDireita = 1 + AlturaArvore(atual.direito, ref balanceada);
                alturaEsquerda = 1 + AlturaArvore(atual.esquerdo, ref balanceada);
                if (alturaDireita > alturaEsquerda)
                    result = alturaDireita;
                else
                    result = alturaEsquerda;
                if (Math.Abs(alturaDireita - alturaEsquerda) > 1)
                    balanceada = false;
            }
            else
                result = 0;
            return result;
        }

        public int altura(NoArvore<Dado> noAtual, ref bool balanceada)
        {
            int alturaEsquerda,
            alturaDireita;
            if (noAtual == null)
                return 0;
            alturaEsquerda = altura(noAtual.esquerdo, ref balanceada);
            alturaDireita = altura(noAtual.direito, ref balanceada);

            if (Math.Abs(alturaDireita - alturaEsquerda) > 1)
                balanceada = false;

            if (alturaEsquerda >= alturaDireita)
                return 1 + alturaEsquerda;
            return 1 + alturaDireita;
        }
        public void DesenharArvore(bool primeiraVez, NoArvore<Dado> atual,
                                   int x, int y, double angulo, double incremento,
                                   double comprimento)
        {
            int xf, yf;
            if (atual != null)
            {
                Graphics g = OndeExibir.CreateGraphics();

                Pen caneta = new Pen(Color.Red);
                SizeF tamanhoF = OndeExibir.CreateGraphics().MeasureString(atual.Info.ToString(), new Font("Comic Sans", 12));
                xf = (int)Math.Round(x + Math.Cos(angulo) * comprimento);
                yf = (int)Math.Round(y + Math.Sin(angulo) * comprimento);
                if (primeiraVez)
                    yf = 25;
                g.DrawLine(caneta, x, y, xf, yf);
                // sleep(100);
                DesenharArvore(false, atual.esquerdo, xf, yf, Math.PI / 2 + incremento,
                                                 incremento * 0.60, comprimento * 0.8);
                DesenharArvore(false, atual.direito, xf, yf, Math.PI / 2 - incremento,
                                                  incremento * 0.60, comprimento * 0.8);
                // sleep(100);
                SolidBrush preenchimento = new SolidBrush(Color.Blue);
                g.FillEllipse(preenchimento, xf - tamanhoF.Width / 2, yf - tamanhoF.Height/2 - 2, tamanhoF.Width, tamanhoF.Height + 4);
                g.DrawString(Convert.ToString(atual.Info.ToString()), new Font("Comic Sans", 12),
                              new SolidBrush(Color.Yellow), xf - tamanhoF.Width/2, yf - tamanhoF.Height/2);
            }
        }

    }
}
