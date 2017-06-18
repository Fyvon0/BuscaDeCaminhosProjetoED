using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _16164_16187_Projeto4ED
{
    public class Caminho : IComparable<Caminho>
    {
        public const int TAMANHO_DA_DISTANCIA = 1;
        public static readonly int DISTANCIA_EM_BYTES = TAMANHO_DA_DISTANCIA * Marshal.SizeOf(typeof(int));
        public static readonly int TAMANHO_DO_REGISTRO = Cidade.NOME_EM_BYTES + Cidade.NOME_EM_BYTES + DISTANCIA_EM_BYTES;

        protected Cidade saida, destino;
        protected int distancia;

        public Caminho (Cidade cidadeSaida, Cidade cidadeDestino, int distanciaCidades)
        {
            saida = cidadeSaida;
            destino = cidadeDestino;
            distancia = distanciaCidades;
        }

        public Caminho (String cidadeSaida, String cidadeDestino, int distanciaCidades)
        {
            saida = new Cidade(cidadeSaida, 0D, 0D);
            destino = new Cidade(cidadeDestino, 0D, 0D);
            if (distanciaCidades < 0)
                distanciaCidades = 10000;
            distancia = distanciaCidades;
        }

        public Cidade Saida
        {
            get { return saida; }
        }

        public Cidade Destino
        {
            get { return destino; }
        }

        public int Distancia
        {
            get { return distancia; }

            set
            {
                if (value >= 0)
                    distancia = value;
            }
        }

        public override String ToString ()
        {
            String partida = saida.Nome.Trim();
            String chegada = destino.Nome.Trim();
            return partida + " - " + chegada + ": " + distancia + "km";
        }

        public int CompareTo (Caminho outro)
        {
            return (this.saida.Nome + this.destino.Nome).CompareTo(outro.saida.Nome + outro.destino.Nome);
        }
    }
}
