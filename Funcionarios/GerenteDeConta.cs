using ByteBank.Sistema;
using ByteBank.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    class GerenteDeConta : FuncionarioAutenticavel
    {
        public GerenteDeConta(string cpf) : base(4000, cpf) //preenchendo o construtor do AUTENTICAVEL
        {
        }

        public override void AumentarSalario()
        {
            Salario *= 1.05;
        }

        public override double GetBonificacao()
        {
            return Salario * 0.25;
        }
    }
}
