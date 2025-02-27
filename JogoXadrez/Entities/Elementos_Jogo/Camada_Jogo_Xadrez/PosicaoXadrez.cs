using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro.Enum;

namespace JogoXadrez.Entities.Elementos_Jogo.Camada_Jogo_Xadrez
{   
    //Criamos essa classe pois a lógica de posições em uma tabuleiro de xadrez é diferente da lógica de uma matriz
    //Tanto na numeração , quanto nos elementos utilizados

    //Vamos converter a posição do xadrez para uma posiçãod a matriz
    class PosicaoXadrez
    {
        public int Linha { get; private set; }
        public char Coluna { get; set; }
   
        public PosicaoXadrez(int linha, char coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public Posicao Convert()
        {
            //a internamente é um número inteiro
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            return "" + Coluna + Linha; 
        }

    }
}
