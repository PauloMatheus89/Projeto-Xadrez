using JogoXadrez;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Jogo_Xadrez;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro.Enum;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro.TabuleiroExceptions;
using System;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro.TabuleiroExceptions;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Jogo_Xadrez.RegrasExceptions;
using System.Runtime.ConstrainedExecution;


namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PartidaXadrez partida = new PartidaXadrez();

            while (!partida.Finalizada)
            {


                try
                {
                    Console.Clear();
                    Tela.imprimirPartida(partida);
                    Console.WriteLine();

                    Posicao origem, destino;

                    //Recebemos 1 posição
                    Console.Write("Origem: ");
                    origem = Tela.lerPosicaoXadrez().Convert();
                    
                    partida.ValidarPosicaoOrigem(origem);

                    bool[,] posicoesPossiveis = partida.Tab.indentificarPeca(origem).movimentoPeca();

                    Tela.imprimirTabuleiro(partida.Tab, posicoesPossiveis);

                    Console.WriteLine();

                    Console.Write("Destino: ");
                    destino = Tela.lerPosicaoXadrez().Convert();

                    partida.ValidarPosicaoDestino(destino, posicoesPossiveis);



                    partida.realizaJogada(origem, destino);

                    Console.Clear();

                    Tela.imprimirTabuleiro(partida.Tab);
                }
                catch (JogadaException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }

            }
        }

    }

    //Método que imprime a tela
    //Não está na camada de tabuleiro

}


/*
 
3 camadas do projeto:

- Camada de Aplicação (Unity)

- Camada Jogo de Xadrez - Elementos específicos do jogo de xadrez

- Camada Tabuleiro - Elementos presentes e referentes a qualquer tabuleiro
 
*/