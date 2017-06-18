using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16164_16187_Projeto4ED
{
    class VerticeCidade : Vertice, IComparable<VerticeCidade>
    {
        protected Cidade cidade;

        public VerticeCidade (String label, Cidade info) : base(label)
        {
            cidade = info;
        }

        public Cidade Info
        {
            get { return cidade; }
        }

        public int CompareTo(VerticeCidade other)
        {
            return this.rotulo.CompareTo(other.rotulo);
        }
    }
}
