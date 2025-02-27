using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro.TabuleiroExceptions
{
    class PositionException : ApplicationException
    {
        public PositionException(string message) : base(message)
        {

        }
    }
}
