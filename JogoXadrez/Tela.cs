using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro.Enum;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Jogo_Xadrez;
using System.Runtime.Intrinsics.X86;


namespace JogoXadrez
{
    class Tela
    {

        public static void imprimirPartida(PartidaXadrez partida)
        {
            imprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Peças Capturadas: ");
            imprimirCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno : " + partida.Turno);
            Console.WriteLine("Aguardando Jogador: " + partida.JogadorAtual);
            Console.WriteLine("Rei em xeque: " + partida.Xeque);
        }

        public static void imprimirCapturadas(PartidaXadrez partida)
        {
            Console.WriteLine("Brancas: " + partida.qtdCapturadas(Cor.Branco));
            imprimirConjunto(partida.DescobrirPecasCapturadas(Cor.Branco));
            
            Console.WriteLine();
            
            Console.WriteLine("Pretas: " + partida.qtdCapturadas(Cor.Preto));
            imprimirConjunto(partida.DescobrirPecasCapturadas(Cor.Preto));

        }
        
        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach(Peca peca in conjunto)
            {
                Console.Write(peca + " ");
            }
            Console.Write("]");
        }
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for(int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8-i + " ");
                for(int c = 0; c<tab.Colunas; c++)
                {
                    imprimirPeca(tab.indentificarPeca(i, c));       
                }
                Console.WriteLine();
            }
            Console.Write(" ");
            for(char i = 'a'; i< 'i'; i++)
            {
                Console.Write(" " + i);
            }
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoAlterado = ConsoleColor.Red;
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int c = 0; c < tab.Colunas; c++)
                {
                    if (posicoesPossiveis[i,c])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.indentificarPeca(i, c));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.Write(" ");
            for (char i = 'a'; i < 'i'; i++)
            {
                Console.Write(" " + i);
            }
            Console.BackgroundColor = fundoOriginal;
        }



        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string posicao = Console.ReadLine();

            char coluna = posicao[0];
            int linha = int.Parse(posicao[1] + "");

            return (new PosicaoXadrez(linha, coluna));
            
        }

        //Impressão em diferentes cores
        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branco)
                {
                    Console.Write(peca + " ");
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(peca + " ");
                    Console.ForegroundColor = aux;
                }
            }
        }


    }

}
