using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    //Toda classe que trata uma exceção deriva da classe EXCEPTION, portanto, é necessário herda-la: 
    public class SaldoInsuficienteException : OperacaoFinanceiraException
    {
        //Propriedade que guarda as informações da parte de código: "public SaldoInsuficienteException(double saldo, double valorSaque)";
        public double Saldo { get; } //Sem set pois esse valor nunca irá mudar;
        public double ValorSaque { get; } //Propriedade somente leitura (por baixo dos panos existe um readonly);


        //Construtor que não recebe argumentos, precisa mante-lo aqui p/ que não bug o método Sacar na classe ContaCorrente;
        public SaldoInsuficienteException()
        {

        }

        //Construtor que recebe como argumento o saldo da conta e o valor que houve a tentativa de saque;
        public SaldoInsuficienteException(double saldo, double valorSaque)
            : this("Tentativa de saque do valor de " + valorSaque + " em uma conta com saldo de " + saldo)                       
            // esse this chama o construtor do bloco abaixo que contém o construtor base, e passamos a mensagem personalizada;
        {
            Saldo = saldo;
            ValorSaque = ValorSaque;
        }
        //Construtor com argumentos que recebe uma mensagem, esse construtor chama o construtor da base;
        public SaldoInsuficienteException(string mensagem)
            : base(mensagem) //Construtor da classe base que recebe a mensagem de cima;
            // essa base de cima seta a propriedade (ex.Message); 
        {

        }

    }
}
 