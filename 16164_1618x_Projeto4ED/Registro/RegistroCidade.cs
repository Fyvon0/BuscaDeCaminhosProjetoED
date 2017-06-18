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
        /// Grava um registro de Cidade na posição especificada do arquivo
        /// </summary>
        /// <param name="f">Arquivo de escrita</param>
        /// <param name="posicao">Posição em que o registro deverá ser escrito</param>
        /// <param name="dados">Cidade que deverá ser escrita no arquivo</param>
        public override void GravarRegistro(FileStream f, long posicao, Cidade dados)
        {
            try
            {
                f.Seek(posicao * Cidade.TAMANHO_DO_REGISTRO, SeekOrigin.Begin); // Busca a posição especificada
            }
            finally
            {
                EscreverString(f, dados.Nome, Cidade.TAMANHO_DO_NOME); // Escreve o nome da cidade

                byte[] doubleBytes = BitConverter.GetBytes(dados.RazaoX); // Escreve as razões da posição da cidade
                byte[] result = doubleBytes;
                f.Write(result, 0, Cidade.RAZAO_EM_BYTES);

                doubleBytes = BitConverter.GetBytes(dados.RazaoY);
                result = doubleBytes;
                f.Write(result, 0, Cidade.RAZAO_EM_BYTES);
            }
        }

        /// <summary>
        /// Lê um registro de Cidade da posição especificada do arquivo
        /// </summary>
        /// <param name="f">Arquivo a ser lido</param>
        /// <param name="posicao">Posição a ser lida</param>
        /// <param name="dados">Objeto que armazenará as informações lidas</param>
        public override void LerRegistro(FileStream f, long posicao, ref Cidade dados)
        {
            byte[] nomeLido = new byte[Cidade.NOME_EM_BYTES];
            byte[] razaoX = new byte[Cidade.RAZAO_EM_BYTES];
            byte[] razaoY = new byte[Cidade.RAZAO_EM_BYTES];

            f.Seek(posicao * Cidade.TAMANHO_DO_REGISTRO, SeekOrigin.Begin);
            
            f.Read(nomeLido, 0, Cidade.NOME_EM_BYTES); // Lê as informações dos arquivos
            f.Read(razaoX, 0, Cidade.RAZAO_EM_BYTES);
            f.Read(razaoY, 0, Cidade.RAZAO_EM_BYTES);

            string Nome = "";
            for (int i = 0; i < Cidade.TAMANHO_DO_NOME; i++) // Adapta os caracteres lidos para UTF-32
                Nome += Char.ConvertFromUtf32(nomeLido[i]);
            dados.Nome = Nome;

            dados.RazaoX = BitConverter.ToDouble(razaoX, 0); // Converte os bytes para Double

            dados.RazaoY = BitConverter.ToDouble(razaoY, 0);    
        }
    }
}
