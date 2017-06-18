using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _16164_16187_Projeto4ED
{
    public class ArvoreDeBusca<Tipo> : IComparable<NoArvore<Tipo>>
                                                where Tipo : IComparable<Tipo>
    {
        public NoArvore<Tipo> raiz,
                                 atual,
                                 antecessor;

        public Panel painelArvore;

        public Panel OndeExibir
        {
            get { return painelArvore; }
            set { painelArvore = value; }
        }

        public ArvoreDeBusca()
        {
            raiz = null;
            atual = null;
            antecessor = null;
        }

        public NoArvore<Tipo> Raiz
        {
            get { return raiz; }
        }

        public String InOrdem  // propriedade que gera a string do percurso in-ordem da �rvore
        {
            get { return FazInOrdem(raiz); }
        }

        public String PreOrdem  // propriedade que gera a string do percurso pre-ordem da �rvore
        {
            get { return FazPreOrdem(raiz); }
        }

        public String PosOrdem  // propriedade que gera a string do percurso pos-ordem da �rvore
        {
            get { return FazPosOrdem(raiz); }
        }

        private String FazInOrdem(NoArvore<Tipo> r)
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

        private String FazPreOrdem(NoArvore<Tipo> r)
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


        private String FazPosOrdem(NoArvore<Tipo> r)
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

        public int CompareTo(NoArvore<Tipo> o)
        {
            return atual.Info.CompareTo(o.Info);
        }

        public int QuantosNos
        {
            get { return qtosNos(raiz); }
        }

        private int qtosNos(NoArvore<Tipo> noAtual)
        {
            if (noAtual == null)
                return 0;
            else
                return 1 + // conta o n� atual
                qtosNos(noAtual.esquerdo) + // conta n�s da sub�rvore esquerda
                qtosNos(noAtual.direito); // conta n�s da sub�rvore direita
        }

        public void inserir(Tipo novosDados)
        {
            bool achou = false, fim = false;
            NoArvore<Tipo> novoNo = new NoArvore<Tipo>(novosDados);
            if (raiz == null)         // �rvore vazia
                raiz = novoNo;
            else                         // �rvore n�o-vazia
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
                            antecessor.esquerdo = novoNo;
                            fim = true;
                        }
                    }
                    else
                        if (novosDados.CompareTo(atual.Info) == 0)
                        achou = true;  // pode-se disparar uma exce��o neste caso
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

        public bool ApagarNo(Tipo chaveARemover)
        {
            atual = raiz;
            antecessor = null;
            bool ehFilhoEsquerdo = true;
            while (atual.Info.CompareTo(chaveARemover) != 0)  // enqto n�o acha a chave a remover
            {
                antecessor = atual;
                if (atual.Info.CompareTo(chaveARemover) > 0)
                {
                    ehFilhoEsquerdo = true;
                    atual = atual.esquerdo;
                }
                else
                {
                    ehFilhoEsquerdo = false;
                    atual = atual.direito;
                }

                if (atual == null)  // neste caso, a chave a remover n�o existe e n�o pode
                    return false;   // ser exclu�da, dai retornamos falso indicando isso
            }  // fim do while

            // se fluxo de execu��o vem para este ponto, a chave a remover foi encontrada
            // e o ponteiro atual indica o n� que cont�m essa chave

            if ((atual.esquerdo == null) && (atual.direito == null))  // � folha, n� com 0 filhos
            {
                if (atual == raiz)
                    raiz = null;   // exclui a raiz e a �rvore fica vazia
                else
                    if (ehFilhoEsquerdo)        // se for filho esquerdouerdo, o antecessor deixar� 
                    antecessor.esquerdo = null;  // de ter um descendente esquerdouerdo
                else                               // se for filho direitoeito, o antecessor deixar� de 
                    antecessor.direito = null;  // apontar para esse filho

                atual = antecessor;  // feito para atual apontar um n� v�lido ao sairmos do m�todo
            }
            else   // verificar� as duas outras possibilidades, exclus�o de n� com 1 ou 2 filhos
                if (atual.direito == null)   // neste caso, s� tem o filho esquerdouerdo
            {
                if (atual == raiz)
                    raiz = atual.esquerdo;
                else
                    if (ehFilhoEsquerdo)
                    antecessor.esquerdo = atual.esquerdo;
                else
                    antecessor.direito = atual.esquerdo;
                atual = antecessor;
            }
            else
                    if (atual.esquerdo == null)  // neste caso, s� tem o filho direitoeito
            {
                if (atual == raiz)
                    raiz = atual.direito;
                else
                    if (ehFilhoEsquerdo)
                    antecessor.esquerdo = atual.direito;
                else
                    antecessor.direito = atual.direito;
                atual = antecessor;
            }
            else // tem os dois descendentes
            {
                NoArvore<Tipo> menorDosMaiores = ProcuraMenorDosMaioresDescendentes(atual);
                atual.Info = menorDosMaiores.Info;
                menorDosMaiores = null; // para liberar o n� trocado da mem�ria
            }
            return true;
        }

        public NoArvore<Tipo> ProcuraMenorDosMaioresDescendentes(NoArvore<Tipo> noAExcluir)
        {
            NoArvore<Tipo> paiDoSucessor = noAExcluir;
            NoArvore<Tipo> sucessor = noAExcluir;
            NoArvore<Tipo> atual = noAExcluir.direito;   // vai ao ramo direitoeito do n� a ser exclu�do, pois este ramo cont�m
            // os descendentes que s�o maiores que o n� a ser exclu�do 
            while (atual != null)
            {
                if (atual.esquerdo != null)
                    paiDoSucessor = atual;
                sucessor = atual;
                atual = atual.esquerdo;
            }

            if (sucessor != noAExcluir.direito)
            {
                paiDoSucessor.esquerdo = sucessor.direito;
                sucessor.direito = noAExcluir.direito;
            }
            return sucessor;
        }

        public int alturaArvore(NoArvore<Tipo> atual, ref bool balanceada)
        {
            int alturaDireita, alturaEsquerda, result;
            if (atual != null && balanceada)
            {
                alturaEsquerda = 1 + alturaArvore(atual.esquerdo, ref balanceada);
                alturaDireita = 1 + alturaArvore(atual.direito, ref balanceada);
                result = Math.Max(alturaEsquerda, alturaDireita);

                //if (alturaDireita > alturaEsquerda)
                //    result = alturaDireita;
                //else
                //  result = alturaEsquerda;

                if (Math.Abs(alturaDireita - alturaEsquerda) > 1)
                    balanceada = false;
            }
            else
                result = 0;
            return result;
        }

        public void DesenharArvore(bool primeiraVez, NoArvore<Tipo> atual,
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
                g.FillEllipse(preenchimento, xf - tamanhoF.Width / 2, yf - tamanhoF.Height / 2 - 2, tamanhoF.Width, tamanhoF.Height + 4);
                g.DrawString(Convert.ToString(atual.Info.ToString()), new Font("Comic Sans", 12),
                              new SolidBrush(Color.Yellow), xf - tamanhoF.Width / 2, yf - tamanhoF.Height / 2);
            }
        }
    }
}
