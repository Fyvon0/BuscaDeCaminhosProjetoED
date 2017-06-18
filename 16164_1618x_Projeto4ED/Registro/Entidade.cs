using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _16164_16187_Projeto4ED
{
    public abstract class Entidade<Dado> 
           where Dado : IComparable<Dado>
    {
        public abstract void LerRegistro(FileStream f, long posicao, ref Dado dados);
        public abstract void GravarRegistro(FileStream f, long posicao, Dado dados);
        public abstract void EscreverString(FileStream f, String s, int tamanho);
    }

}
