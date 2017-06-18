using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16164_16187_Projeto4ED
{
    public class ListaCaminhos : ListaSimples<Caminho>
    {
        public ListaCaminhos (): base()
        { }

        public void ExcluirCidade (String nomeCidade)
        {
            anterior = null;
            atual = primeiro;
            while (atual != null)
            {
                if (atual.Info.Destino.ToString() == nomeCidade || atual.Info.Saida.ToString() == nomeCidade)
                {
                    if (atual == primeiro)
                        primeiro = atual.Prox;
                    else
                        anterior.Prox = atual.Prox;

                    if (atual == ultimo)
                        ultimo = anterior;

                    atual = atual.Prox;
                    quantosNos--;
                }
                else
                {
                    anterior = atual;
                    atual = atual.Prox;
                }
            }
        }
    }
}
