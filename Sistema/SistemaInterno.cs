using ByteBank.Funcionarios;
using ByteBank.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Sistema
{
    public class SistemaInterno
    {
        public bool Logar(IAutenticavel funcionario, string senha) //Sistema interno espera um AUTENTICAVEL 
        {
            bool usuarioAutenticado = funcionario.Autenticar(senha);

            if (usuarioAutenticado)
            {   
                Console.WriteLine("Bem-vindo ao sistema!");
                return true;
            } 
            else
            {
                Console.WriteLine("Senha incorreta!");
                return false;
            }
        }
    }
}
