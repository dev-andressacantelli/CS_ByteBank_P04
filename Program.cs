using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CarregarContas();
            }
            catch (Exception)
            {
                Console.WriteLine("CATCH NO METODO MAIN");
            }
            

            Console.WriteLine("Execução finalizada. Tecle enter para sair");
            Console.ReadLine();
        }

        private static void CarregarContas()
        {

            //Descrever a diretiva using aqui, significa que ele está executando o "try catch" por baixo dos panos, abaixo comentado;
            using(LeitorDeArquivo leitor = new LeitorDeArquivo("teste.txt"))
            {
                leitor.LerProximaLinha();
            }

            //***********************************************************************************************************
            //Trecho de código comentado p/ utilizar a diretiva using a cima descrita,  
            //pois no arquivo LeitorDeArquivos fora chamado o método Dispose que é responsável pela liberação de recursos;

            //LeitorDeArquivo leitor = null; 
            ///*Deixa-lo null é tratativa de exceção para que não ocorra erro de caractere, ex:
            //    leitor = new LeitorDeArquivo("contasSS.txt"); 
            //é o arquivo certo, e irá executar normal, portanto caso alterar para, ex:
            //    leitor = new LeitorDeArquivo("contasSS.txt");
            //irá tentar inicializar, porém não coseguirá, cairá em uma exceção e avisará que "leitor" permanece NULL; */

            //try
            //{
            //    leitor = new LeitorDeArquivo("contas.txt");
            //  //leitor = new LeitorDeArquivo("contaSs.txt"); TENTAR ESSA LINHA P/ CAPTURAR EXCEÇÃO;

            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //} 

            ///* Quando temos um finally, não precisamos ter um catch.
            //Trecho de código retirado:
            //catch(IOException)
            //{
            //    Console.WriteLine("Exceção do tipo IOException capturada e tratada!");
            //} */

            //finally
            //{
            //    Console.WriteLine("Executando o finally");
            //    if(leitor != null)
            //    {
            //        leitor.Fechar();
            //    }
            //}
            
        }



        private static void TestaInnerException()
        {
            try
            {
                ContaCorrente conta1 = new ContaCorrente(4564, 789684);
                ContaCorrente conta2 = new ContaCorrente(7891, 456794);

                //conta1.Transferir(10000, conta2);
                conta1.Sacar(10000);
            }
            catch (OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                //Console.WriteLine("Informações da INNER EXCEPTION (exceção interna) :");
            }
        }

        // Teste com a cadeia de chamada:
        // Metodo -> TestaDivisao -> Dividir
        private static void Metodo()
        {
            TestaDivisao(0);
        }

        private static void TestaDivisao(int divisor)
        {
            int resultado = Dividir(10, divisor);
            Console.WriteLine("Resultado da divisão de 10 por " + divisor + " é " + resultado);
        }

        private static int Dividir(int numero, int divisor)
        {
            try
            {
                return numero / divisor;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Exceção com numero=" + numero + " e divisor=" + divisor);
                throw;
                Console.WriteLine("Código depois do throw");
            }
        }

        // numero = 1
        // divisor = 2;
    }
}       

