using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoXadrez.Entities.Elementos_Jogo.Camada_Jogo_Xadrez
{
    class Peao : Peca
    {
        PartidaXadrez partida;
        public Peao(Tabuleiro tab, Cor cor, PartidaXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        public override bool[,] movimentoPeca()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao p = new Posicao(0, 0);

            if(Cor == Cor.Preto)
            {
                //Sem Capturar peças
                p.definirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (QtdMovimentos == 0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (Tabuleiro.verifyPosition(p) && podeMover(p))
                        {
                            mat[p.Linha, p.Coluna] = true;
                        }
                        p.definirValores(p.Linha + 1, p.Coluna);
                    }
                }
                else
                {
                    if (Tabuleiro.verifyPosition(p) && podeMover(p))
                    {
                        mat[p.Linha, p.Coluna] = true;
                    }
                    p.definirValores(p.Linha + 1, p.Coluna);
                }

                //Capturando peça

                //esquerda
                p.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tabuleiro.verifyPosition(p) && podeCapturar(p))
                {
                    mat[p.Linha, p.Coluna] = true;
                }

                //Direita
                p.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiro.verifyPosition(p) && podeCapturar(p))
                {
                    mat[p.Linha, p.Coluna] = true;
                }
            }
            else
            {
                //Sem Capturar peças
                p.definirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (QtdMovimentos == 0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (Tabuleiro.verifyPosition(p) && podeMover(p))
                        {
                            mat[p.Linha, p.Coluna] = true;
                        }
                        p.definirValores(p.Linha - 1, p.Coluna);
                    }
                }
                else
                {
                    if (Tabuleiro.verifyPosition(p) && podeMover(p))
                    {
                        mat[p.Linha, p.Coluna] = true;
                    }
                    p.definirValores(p.Linha + 1, p.Coluna);
                }

                //Capturando peça

                //esquerda
                p.definirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tabuleiro.verifyPosition(p) && podeCapturar(p))
                {
                    mat[p.Linha, p.Coluna] = true;
                }

                //Direita
                p.definirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiro.verifyPosition(p) && podeCapturar(p))
                {
                    mat[p.Linha, p.Coluna] = true;
                }
            }

                return mat;


        }

        public override string ToString()
        {
            return "P";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = Tabuleiro.indentificarPeca(pos);
            return (p == null);
        }

        private bool podeCapturar(Posicao pos)
        {
            Peca p = Tabuleiro.indentificarPeca(pos);
            return (p != null && p.Cor != Cor);
        }
    }
}
