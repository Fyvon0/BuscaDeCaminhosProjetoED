using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16164_16187_Projeto4ED
{
    class RegistroCaminho : Entidade<Caminho>
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

        public override void GravarRegistro(FileStream f, long posicao, Caminho dados)
        {
            try
            {
                f.Seek(posicao * Caminho.TAMANHO_DO_REGISTRO, SeekOrigin.Begin);
            }
            finally
            {
                EscreverString(f, dados.Saida.Nome, Cidade.TAMANHO_DO_NOME);
                EscreverString(f, dados.Destino.Nome, Cidade.TAMANHO_DO_NOME);

                byte[] intBytes = BitConverter.GetBytes(dados.Distancia);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(intBytes);
                byte[] result = intBytes;
                f.Write(result, 0, Caminho.DISTANCIA_EM_BYTES);
            }
        }

        public override void LerRegistro(FileStream f, long posicao, ref Caminho dados)
        {
            byte[] cidadeSaida = new byte[Cidade.NOME_EM_BYTES];
            byte[] cidadeDestino = new byte[Cidade.NOME_EM_BYTES];
            byte[] umInteiro = new byte[Caminho.DISTANCIA_EM_BYTES];

            f.Seek(posicao * Caminho.TAMANHO_DO_REGISTRO, SeekOrigin.Begin);

            f.Read(cidadeSaida, 0, Cidade.NOME_EM_BYTES);
            f.Read(cidadeDestino, 0, Cidade.NOME_EM_BYTES);
            f.Read(umInteiro, 0, Caminho.DISTANCIA_EM_BYTES);

            string saida = "";
            for (int i = 0; i < Cidade.TAMANHO_DO_NOME; i++)
                saida += Char.ConvertFromUtf32(cidadeSaida[i]);
            dados.Saida.Nome = saida;

            string destino = "";
            for (int i = 0; i < Cidade.TAMANHO_DO_NOME; i++)
                destino += Char.ConvertFromUtf32(cidadeDestino[i]);
            dados.Destino.Nome = destino;
            
            dados.Distancia = umInteiro[3]; 
        }
    }
}
