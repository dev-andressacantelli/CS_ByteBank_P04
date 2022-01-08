using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class LeitorDeArquivo : IDisposable
    {
        public string Arquivo { get; }

        public LeitorDeArquivo(string arquivo)
        {
            Arquivo = arquivo;

            //throw new FileNotFoundException(); //Exceção de arquivo não encontrado;

            Console.WriteLine("Abrindo arquivo: " + arquivo);
        }

        public string LerProximaLinha()
        {
            Console.WriteLine("Lendo linha...");

            //IOException: Exceção definida no .net, exceção de input ou output, significa exceção de entrada ou saída;
            throw new IOException();
            //Tentando acessar um arquivo que deu algum problema na entrada ou na saída do HD, então seremos notificados com essa exceção;  

            return "Linha do arquivo";
        }

        //O Dispose é um método que tem a responsabilidade de liberar os recursos; 
        public void Dispose()
        {
            Console.WriteLine("Fechando arquivo.");
        }
    }
}