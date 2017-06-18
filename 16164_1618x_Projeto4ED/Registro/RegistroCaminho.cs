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
        /// <summary>
        /// Escreve a string recebida na posição atual de escrita do arquivo
        /// </summary>
        /// <param name="f">Arquivo de escrita</param>
        /// <param name="s">String a ser escrita</param>
        /// <param name="tamanho">Tamanho padrão da string, para que a leitura possa ser constante</param>
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

        /// <summary>
        /// Grava um registro de Caminho na posição especificada do arquivo
        /// </summary>
        /// <param name="f">Arquivo de escrita</param>
        /// <param name="posicao">Posição em que o registro deverá ser escrito</param>
        /// <param name="dados">Caminho que deverá ser escrito no arquivo</param>
        public override void GravarRegistro(FileStream f, long posicao, Caminho dados)
        {
            try
            {
                f.Seek(posicao * Caminho.TAMANHO_DO_REGISTRO, SeekOrigin.Begin); // Busca a posição especificada
            }
            finally
            {
                EscreverString(f, dados.Saida.Nome, Cidade.TAMANHO_DO_NOME); // Escreve os nomes das cidades
                EscreverString(f, dados.Destino.Nome, Cidade.TAMANHO_DO_NOME);

                byte[] intBytes = BitConverter.GetBytes(dados.Distancia); // Escreve a distância
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(intBytes);
                byte[] result = intBytes;
                f.Write(result, 0, Caminho.DISTANCIA_EM_BYTES);
            }
        }

        /// <summary>
        /// Lê um registro de Caminho da posição especificada do arquivo
        /// </summary>
        /// <param name="f">Arquivo a ser lido</param>
        /// <param name="posicao">Posição a ser lida</param>
        /// <param name="dados">Objeto que armazenará as informações lidas</param>
        public override void LerRegistro(FileStream f, long posicao, ref Caminho dados)
        {
            byte[] cidadeSaida = new byte[Cidade.NOME_EM_BYTES];
            byte[] cidadeDestino = new byte[Cidade.NOME_EM_BYTES];
            byte[] umInteiro = new byte[Caminho.DISTANCIA_EM_BYTES];

            f.Seek(posicao * Caminho.TAMANHO_DO_REGISTRO, SeekOrigin.Begin);

            f.Read(cidadeSaida, 0, Cidade.NOME_EM_BYTES); // Lê as informações dos arquivos
            f.Read(cidadeDestino, 0, Cidade.NOME_EM_BYTES);
            f.Read(umInteiro, 0, Caminho.DISTANCIA_EM_BYTES);

            string saida = "";
            for (int i = 0; i < Cidade.TAMANHO_DO_NOME; i++) // Adapta os caracteres lidos para UTF-32
                saida += Char.ConvertFromUtf32(cidadeSaida[i]);
            dados.Saida.Nome = saida;

            string destino = "";
            for (int i = 0; i < Cidade.TAMANHO_DO_NOME; i++) // Adapta os caracteres lidos para UTF-32
                destino += Char.ConvertFromUtf32(cidadeDestino[i]);
            dados.Destino.Nome = destino;
            
            dados.Distancia = umInteiro[3]; // Lê o inteiro que indica a distância
        }
    }
}
