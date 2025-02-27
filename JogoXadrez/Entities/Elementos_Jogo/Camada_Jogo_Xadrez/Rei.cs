using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro.Enum;

namespace JogoXadrez.Entities.Elementos_Jogo.Camada_Jogo_Xadrez
{
    class Rei : Peca
    {
        private PartidaXadrez partida;
        public Rei(Tabuleiro tab, Cor cor, PartidaXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        public bool testeRoque(Posicao pos)
        {
            Peca p = Tabuleiro.indentificarPeca(pos);

            return p is Torre && p.QtdMovimentos == 0 && p != null && p.Cor == Cor;
        }

        //Aqui definimos os movimentos possiveis, mas a movimentação de fato, está a cargo da PartidaXadrez
        public override bool[,] movimentoPeca()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new Posicao(0, 0);

            //Acima
            //1 - Definimos a Posição que deseja mover a peça
            //2 - Verifica se posição é válida e se é possivel mover para aquela posição
            //3 - Caso sim, coloca true na matriz que representa posições possiveis
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.verifyPosition(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Abaixo
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.verifyPosition(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //direita
            pos.definirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.verifyPosition(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //
            pos.definirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.verifyPosition(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.verifyPosition(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.verifyPosition(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.verifyPosition(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.verifyPosition(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Roque 
            if (!partida.Xeque && QtdMovimentos == 0)
            {
                //Roque Pequeno
                Posicao posT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (testeRoque(posT1))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if (Tabuleiro.indentificarPeca(p1) == null && Tabuleiro.indentificarPeca(p2) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }

                //Roque Grande
                Posicao posT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (testeRoque(posT2))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                    if (Tabuleiro.indentificarPeca(p1) == null && Tabuleiro.indentificarPeca(p2) == null && Tabuleiro.indentificarPeca(p3) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }

            }

            return mat;

        }

        public override string ToString()
        {
            return "R";
        }

        //Esse método não é oq vai mover a peça em si, ele apenas determina para onde a peça pode se mover
        // 1 - Passamos uma posição
        // 2 - Indetificamos a Peça presente naquela posição
        // 3 - Caso peça seja de uma cor diferente ou não houver peça no local - retorna true 
        private bool podeMover(Posicao pos)
        {
            Peca p = Tabuleiro.indentificarPeca(pos);
            return (p == null || p.Cor != Cor);
        }
    }
}
