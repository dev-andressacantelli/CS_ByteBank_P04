using ByteBank.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Sistema
{
    public interface IAutenticavel //Todos os membros de interface são públicos 
    {
        bool Autenticar(string senha);
    }
}
