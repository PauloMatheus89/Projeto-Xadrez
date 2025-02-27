using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoXadrez.Entities.Elementos_Jogo.Camada_Jogo_Xadrez.RegrasExceptions
{
    class JogadaException : ApplicationException
    {
        public JogadaException(string message) : base(message)
        {
            
        }
    }
}
