using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16164_16187_Projeto4ED
{
    class Vertice
    {
        public bool   foiVisitado;
        public string rotulo;

        public Vertice(string label)
        {
            rotulo = label;
            foiVisitado = false;
        }

    }
}
