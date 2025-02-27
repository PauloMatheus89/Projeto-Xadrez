using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoXadrez.Entities.Elementos_Jogo.Camada_Jogo_Xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "C";
        }

        public bool podeMover(Posicao pos)
        {
            Peca p = Tabuleiro.indentificarPeca(pos);

            return (p == null || p.Cor != Cor);
        }

        public override bool[,] movimentoPeca()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao p = new Posicao(0,0);

            //Um cavalo pode se mover para os dois espaços a adjacentes a posição [linha +- 2, Coluna] ou [linha , Coluna +-2 ]

            //Posições Acima

            p.definirValores(Posicao.Linha + 2, Posicao.Coluna +1);
            if(Tabuleiro.verifyPosition(p) && podeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }

            p.definirValores(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (Tabuleiro.verifyPosition(p) && podeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }

            //Posições á esquerda
            p.definirValores(Posicao.Linha + 1, Posicao.Coluna - 2 );
            if (Tabuleiro.verifyPosition(p) && podeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }

            p.definirValores(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (Tabuleiro.verifyPosition(p) && podeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }

            //Posições a Direita
            p.definirValores(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (Tabuleiro.verifyPosition(p) && podeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }

            p.definirValores(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tabuleiro.verifyPosition(p) && podeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }

            //Posições abaixo
            p.definirValores(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (Tabuleiro.verifyPosition(p) && podeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }

            p.definirValores(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (Tabuleiro.verifyPosition(p) && podeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }

            return mat;

        }
    }
}
