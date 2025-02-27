using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoXadrez.Entities.Elementos_Jogo.Camada_Jogo_Xadrez.RegrasExceptions
{
    class JogadorException : ApplicationException
    {
        public JogadorException(string message) : base(message)
        {

        }
    }
}
