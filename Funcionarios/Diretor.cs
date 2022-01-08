using ByteBank.Sistema;
using ByteBank.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    public class Diretor : FuncionarioAutenticavel  

    {
        public Diretor(string cpf) : base(5000, cpf)
        {
            Console.WriteLine("Criando DIRETOR");
        }

        //Quando utiliza-se o OVERRIDE na classe derivada, significa que:
        //Na classe base existe um método que eu posso subscrever aqui!
        //Precisa utilizar o virtual na classe base!
        public override void AumentarSalario()
        {
            Salario *= 1.15;
        }


        public override double GetBonificacao()
        {
            return Salario * 0.5; //Bonificação de 50%
        }
    }
}
