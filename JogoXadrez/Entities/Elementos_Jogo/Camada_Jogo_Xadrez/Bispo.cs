using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro.Enum;

namespace JogoXadrez.Entities.Elementos_Jogo.Camada_Jogo_Xadrez
{
    class Bispo : Peca
    {
        public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override bool[,] movimentoPeca()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao p = new Posicao(0, 0);

            //PARA FRENTE

            //(Direita)
            p.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while(Tabuleiro.verifyPosition(p) && podeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
                //Quando capturamos uma peça de outra cor, o movimento deve parar

                if(Tabuleiro.indentificarPeca(p) != null && Tabuleiro.indentificarPeca(p).Cor != Cor)
                {
                    break;
                }
                p.definirValores(p.Linha + 1, p.Coluna + 1);
            }

            //Esquerda
            p.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tabuleiro.verifyPosition(p) && podeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
                //Quando capturamos uma peça de outra cor, o movimento deve parar

                if (Tabuleiro.indentificarPeca(p) != null && Tabuleiro.indentificarPeca(p).Cor != Cor)
                {
                    break;
                }
                p.definirValores(p.Linha + 1, p.Coluna - 1);
            }

            //PARA TRAS

            //Direita
            p.definirValores(Posicao.Linha - 1 , Posicao.Coluna + 1);
            while (Tabuleiro.verifyPosition(p) && podeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
                //Quando capturamos uma peça de outra cor, o movimento deve parar

                if (Tabuleiro.indentificarPeca(p) != null && Tabuleiro.indentificarPeca(p).Cor != Cor)
                {
                    break;
                }
                p.definirValores(p.Linha - 1, p.Coluna + 1);
            }

            //Esquerda
            p.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tabuleiro.verifyPosition(p) && podeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
                //Quando capturamos uma peça de outra cor, o movimento deve parar

                if (Tabuleiro.indentificarPeca(p) != null && Tabuleiro.indentificarPeca(p).Cor != Cor)
                {
                    break;
                }
                p.definirValores(p.Linha - 1, p.Coluna - 1);
            }

            return mat;
        }

        public override string ToString()
        {
            return "B";
        }

        public bool podeMover(Posicao pos)
        {
            Peca p = Tabuleiro.indentificarPeca(pos);
            
            return (p == null || p.Cor != Cor);
            
        }
    }
}
