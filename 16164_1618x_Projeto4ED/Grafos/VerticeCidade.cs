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

        /// <summary>
        /// Guarda as informações dessa cidades e chama o construtor da classe base com o nome da cidade
        /// </summary>
        /// <param name="info">Cidade a ser incluída</param>
        public VerticeCidade (Cidade info) : base(info.ToString())
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
