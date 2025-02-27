using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoXadrez.Entities.Elementos_Jogo.Camada_Jogo_Xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override bool[,] movimentoPeca()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao p = new Posicao(0,0);

            //Horizontal

            // 1 - Definimos a Posição, começando da primeira casa após a casa da peça 
            // 2 - Fazemos um loop para testar se a posição é válida, e se a peça pode se mover para lá
            // 3 - Se true (Sinalizamos an matriz que essa posição é true)
            // 4 - incrementamos ou decrementamos a coluna em 1
            // 5 - O laço para caso a coluna adiante nã seja válida ou não seja se moviemntar para ela


            //Obs: Fizemos 2 laços para testar as posições a frente e atras

            //Vertical

            // 1 - Definimos a Posição, começando da primeira casa após a casa da peça 
            // 2 - Fazemos um loop para testar se a posição é válida, e se a peça pode se mover para lá
            // 3 - Se true (Sinalizamos an matriz que essa posição é true)
            // 4 - incrementamos ou decrementamos a coluna em 1
            // 5 - O laço para caso a linha adiante não seja válida ou não seja se moviemntar para ela

            //Minha Implementação
            //Cima
            p.definirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.verifyPosition(p) && podeMover(p) )
            {
                mat[p.Linha, p.Coluna] = true;
                if (Tabuleiro.indentificarPeca(p) != null && Tabuleiro.indentificarPeca(p).Cor != Cor)
                {
                    break;
                }
                p.definirValores(p.Linha + 1, p.Coluna);
            }


            //baixo
            p.definirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.verifyPosition(p) && podeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
                if (Tabuleiro.indentificarPeca(p) != null && Tabuleiro.indentificarPeca(p).Cor != Cor)
                {
                    break;
                }
                p.definirValores(p.Linha - 1, p.Coluna);
            }

            //Direita
            p.definirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.verifyPosition(p) && podeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
                if (Tabuleiro.indentificarPeca(p) != null && Tabuleiro.indentificarPeca(p).Cor != Cor)
                {
                    break;
                }
                p.definirValores(p.Linha, p.Coluna + 1);
            }

            //Esquerda
            p.definirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.verifyPosition(p) && podeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
                if (Tabuleiro.indentificarPeca(p) != null && Tabuleiro.indentificarPeca(p).Cor != Cor)
                {
                    break;
                }
                p.definirValores(p.Linha, p.Coluna - 1);
            }

            return mat;

            /* Implementação do Professor:
            p.definirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (podeMover(p) && Tabuleiro.verifyPosition(p))
            {
                mat[p.Linha, p.Coluna] = true; 
                if(Tabuleiro.verifyPosition(p) && Tabuleiro.indentificarPeca(p).Cor != Cor)
                {
                    break;
                }
                p.definirValores(p.Linha + 1, p.Coluna);

            //Pontos de Melhora:

            - While funciona melhor que o do while, pois o teste ja ocorre no começo, impedindo que ele entre no laço se for false
            - Não precisamos de um if, pois todas as posições antes de uma peça inimiga ou aliada
            }
            */



        }

        public override string ToString()
        {
            return "T";
        }

        public bool podeMover(Posicao pos)
        {
            Peca p = Tabuleiro.indentificarPeca(pos);
            return (p == null || p.Cor != Cor);
        }
    }
}
