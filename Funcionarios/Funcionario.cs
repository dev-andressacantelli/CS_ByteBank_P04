
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    public abstract class Funcionario
    {
        public static int TotalDeFuncionarios { get; private set; }

        public string Nome { get; set; }
        public string CPF { get; private set; }
        public double Salario { get; protected set; } //Protected acessa o seter da classe FUNCIONARIO e DIRETOR (raiz e derivada)
       


        public Funcionario(double salario, string cpf)
        {
            Console.WriteLine("Criando FUNCIONÁRIO");

            CPF = cpf;
            Salario = salario;

            TotalDeFuncionarios++;
        }


        //Quando utilizamos abstract num método, significa que ele poderá
        public abstract void AumentarSalario();
        public abstract double GetBonificacao();

        /* Quando utiliza-se o VIRTUAL na classe base, significa que: Classes que derivam do meu tipo, ou seja,
      classes que herdam o meu tipo podem mudar essa assinatura, podem mudar essa implementação.
      Precisa utilizar override na classe derivada! EX:

      public virtual double GetBonificacao()
      {
          return Salario* 0.10;
      } */

    }
}