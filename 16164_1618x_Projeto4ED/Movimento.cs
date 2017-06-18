// 14178 - Lucas Doi Ryu
// 16164 - Felipe Martins Romeiro

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16164_16187_Projeto4ED
{
    class Movimento : IComparable<Movimento>
    {
        private int cidade, saida; // onde estou, para onde vou
        public Movimento()
        {
            cidade = 0;
            saida = 0;
        }
        public void setValores(int c, int s)
        {
            cidade = c;
            saida = s;
        }
        public int getCidade()
        {
            return cidade;
        }
        public int getSaida()
        {
            return saida;
        }
        public String ToString()
        {
            return cidade + " " +saida;
        }

        public int CompareTo(Movimento other)
        {
            throw new NotImplementedException();
        }
    }
}
