using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _16164_16187_Projeto4ED
{
    public class Cidade : IComparable<Cidade>
    {
        public const int TAMANHO_DO_NOME = 30;
        public const int TAMANHO_DA_RAZAO = 1;

        public static readonly int NOME_EM_BYTES = TAMANHO_DO_NOME * Marshal.SizeOf(typeof(char));
        public static readonly int RAZAO_EM_BYTES = TAMANHO_DA_RAZAO * Marshal.SizeOf(typeof(Double));
        public static readonly int TAMANHO_DO_REGISTRO = NOME_EM_BYTES + RAZAO_EM_BYTES + RAZAO_EM_BYTES;

        protected String nome;
        protected Double rx, ry;

        public Cidade (String nomeCidade, double razaoX, double razaoY)
        {
            if (nomeCidade.Length > TAMANHO_DO_NOME)
                nomeCidade = nomeCidade.Substring(0, TAMANHO_DO_NOME);
            while (nomeCidade.Length < TAMANHO_DO_NOME)
                nomeCidade += " ";
            nome = nomeCidade;
            if (razaoX > 0 && razaoX <= 1)
                rx = razaoX;
            if (razaoY > 0 && razaoY <= 1)
                ry = razaoY;
        }

        public String Nome
        {
            get { return nome; }

            set
            {
                if (value.Length > TAMANHO_DO_NOME)
                    value = value.Substring(0, TAMANHO_DO_NOME);
                while (value.Length < TAMANHO_DO_NOME)
                    value += " ";
                nome = value;
            }
        }

        public Double RazaoX
        {
            get { return rx; }
            set { if (value > 0D && value <= 1D) rx = value; }
        }

        public Double RazaoY
        {
            get { return ry; }
            set { if (value > 0D && value <= 1D) ry = value; }
        }

        public int CompareTo(Cidade outra)
        {
            return this.nome.CompareTo(outra.nome);
        }

        public override String ToString()
        {
            return nome.Trim();
        }
    }
}
