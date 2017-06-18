using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16164_16187_Projeto4ED
{
    class RegistroCidade : Entidade<Cidade>
    {
        public override void EscreverString(FileStream f, string s, int tamanho)
        {
            StringBuilder cadeia = null;
            if (s != null)
                cadeia = new StringBuilder(s);
            else
                cadeia = new StringBuilder(tamanho);
            cadeia.Length = tamanho;
            Byte[] bytes = Encoding.ASCII.GetBytes(cadeia.ToString());
            f.Write(bytes, 0, tamanho);
        }

        public override void GravarRegistro(FileStream f, long posicao, Cidade dados)
        {
            try
            {
                f.Seek(posicao * Cidade.TAMANHO_DO_REGISTRO, SeekOrigin.Begin);
            }
            finally
            {
                EscreverString(f, dados.Nome, Cidade.TAMANHO_DO_NOME);

                byte[] doubleBytes = BitConverter.GetBytes(dados.RazaoX);
                //if (BitConverter.IsLittleEndian)
                //    Array.Reverse(doubleBytes);
                byte[] result = doubleBytes;
                f.Write(result, 0, Cidade.RAZAO_EM_BYTES);

                doubleBytes = BitConverter.GetBytes(dados.RazaoY);
                //if (BitConverter.IsLittleEndian)
                //    Array.Reverse(doubleBytes);
                result = doubleBytes;
                f.Write(result, 0, Cidade.RAZAO_EM_BYTES);
            }
        }

        public override void LerRegistro(FileStream f, long posicao, ref Cidade dados)
        {
            byte[] nomeLido = new byte[Cidade.NOME_EM_BYTES];
            byte[] razaoX = new byte[Cidade.RAZAO_EM_BYTES];
            byte[] razaoY = new byte[Cidade.RAZAO_EM_BYTES];

            f.Seek(posicao * Cidade.TAMANHO_DO_REGISTRO, SeekOrigin.Begin);
            
            f.Read(nomeLido, 0, Cidade.NOME_EM_BYTES);
            f.Read(razaoX, 0, Cidade.RAZAO_EM_BYTES);
            f.Read(razaoY, 0, Cidade.RAZAO_EM_BYTES);

            string Nome = "";
            for (int i = 0; i < Cidade.TAMANHO_DO_NOME; i++)
                Nome += Char.ConvertFromUtf32(nomeLido[i]);
            dados.Nome = Nome;

            dados.RazaoX = BitConverter.ToDouble(razaoX, 0);

            dados.RazaoY = BitConverter.ToDouble(razaoY, 0);    
        }
    }
}
