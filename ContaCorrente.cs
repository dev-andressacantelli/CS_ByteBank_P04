
using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;




namespace ByteBank
{
    public class ContaCorrente
    {
        public static double TaxaOperacao { get; private set; }
        public static int TotalDeContasCriadas { get; private set; }
        public Cliente Titular { get; set; }


        // Contador de saques negados;  
        public int ContadorSaquesNaoPermitidos { get; private set; }
        // Contador de transferencias negadas;
        public int ContadorTransferenciasNaoPermitidas { get; private set; }


        // Escrever o código desta forma:
        public int Numero { get; }
        /* É o mesmo que escrever desta forma:
       
        private readonly int _numero;
        public int Numero 
        {
            get 
            {
                return _numero;
            }
        }                                    */




        // Escrever o código desta forma:
        public int Agencia { get; }

        /* É o mesmo que escrever desta forma:
        
        private int _agencia;
        public int Agencia { 
            get 
            {
                return _agencia;
            }
            private set 
            { 
                if(value <= 0)
                {
                    return;
                }
                _agencia = value; //Isso é um ELSE
            }                                   

        } */


        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value; //Esse trecho é o ELSE;  Todo lugar que tiver "_saldo" é o antigo "this.saldo";
            }
        }


        //ESTE TRECHO É O CONSTRUTOR (ele define que toda criação de um objeto ContaCorrente PRECISA ter agencia e numerodz!
        public ContaCorrente(int agencia, int numero)
        { 
            if(agencia <= 0)
            {
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
            }

           if(numero <= 0)
            {
                throw new ArgumentException("O argumento número deve ser maior que 0.", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++; //seria o mesmo que: ContaCorrente.TotalDeContasCriadas++; (já estamos dentro da classe);
            TaxaOperacao = 30 / TotalDeContasCriadas; //O valor da taxa diminui conforme + contas forem criadas pela pessoa;
        }

        /* O método SACAR anteriormente era booleano com return descritivo, porém p/ quem estivesse utilizado,
        teria que existir uma documentação que explicasse o que cada booleano representa,
        portanto, não seria uma boa solução p/ esse tipo de método, então alteramos p/ VOID + exceção (throw); */
        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor)); 
                //Tratativa de exceção para valores negativos de saldo;
            }


            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++; // contando quantos saques foram tentados;
                throw new SaldoInsuficienteException(Saldo, valor); // Neste momento, preenche a propriedade stacktrace!
                /* Não poderia colocar "throw new Exception" pois é uma maneira muito genérica de tratar uma exceção,
                e quando surgir novos erros, como um de conexão com DB, por exemplo, seria mto complicado tratar esse erro,
                e precisaria lançar um catch junto p/ encontra-lo. 
                Sendo assim, tratamos esse bloco de código com uma exceção que trata o tipo de problema que encontramos aqui,
                além de conseguir mandar uma mensagem personalizada com os construtores na classe SaldoInsuficienteException;  
                */
            }
            else
            {
                _saldo -= valor;
            }
        }

        //Função sem retorno;
        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        //          método            param, classe que possui os campos que eu preciso + segundo param; 
        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
                //Tratativa de exceção para valores negativos de transferência;
            }


            /* Chamando o método SACAR para não repetir código;
            Lançando o contador de transf dentro do catch, 
            p/ não contar caso a transferencia seja de valor 0.*/
            try
            {
                Sacar(valor);
            }
            catch(SaldoInsuficienteException ex) //Dando nome para a exceção que será utilizada logo abaixo; 
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não realizada ", ex);
            }

            /* ANTIGA solução com throw vazio.
               throw; //SOMENTE em caso de catch é possível chamar throw vazio!;
               //Aqui a máquina virtual vê a exceção sendo convocada através do "throw" e localiza o objeto "ex",
               nesse momento preenche a stacktrace que ocorreu essa exceção, 
               mas agora essa exceção tem uma pilha de trilhas diferente, 
               agora a exceção não vai mais considerar o método "Sacar" lá de cima, porque o método "Sacar" já foi abandonado,
               agora voltamos ao método "Transferir", dentro do catch! Sendo assim, o "Sacar" não faz mais parte da pilha de chamadas; */

            contaDestino.Depositar(valor);
        }

    }
}


