using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro
{
    class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Posicao(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        //Ajuda a manipular objetos posição, sem a necessidade de criar novos objetos
        //Ajuda a definir tanto linha como coluna em uma unica linha
        public void definirValores(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public override string ToString()
        {
            return Linha + "," + Coluna;
        }
    }
}
