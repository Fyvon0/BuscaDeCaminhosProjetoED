using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16164_16187_Projeto4ED
{
    public class NoArvore<Dado> where Dado : IComparable<Dado>
    {
        private Dado info;          // Apontador para o objeto genérico que
                                    // armazenamos no campo de informação
                                    // do nó
        public NoArvore<Dado> esquerdo, direito;
        public NoArvore() : this(default(Dado), null, null)
        {      // construtor default
        }
        public NoArvore(Dado informacao, NoArvore<Dado> esq, NoArvore<Dado> dir)
        {
            info = informacao;  // construtor polimórfico com 
            esquerdo = esq;     // parâmetros
            direito = dir;
        }
        public NoArvore(Dado informacao)
        {
            info = informacao;  // construtor polimórfico com 
            esquerdo = null;     // parâmetros
            direito = null;
        }
        public Dado Info
    {
        get { return info; }
        set { info = value; }
    }
    public NoArvore<Dado> Esquerdo
    {
        get { return esquerdo; }
        set { esquerdo = value; }
    }
    public NoArvore<Dado> Direito
    {
        get { return direito; }
        set { direito = value; }
    }
}

}
