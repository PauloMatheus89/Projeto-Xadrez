using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro.Enum;

namespace JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro
{
     abstract class Peca
    {
        public Cor Cor { get; set; } 
        //Toda a Peça possui uma cor

        public  Posicao Posicao { get; set; } 
        //Só pode ser alterada na classe ou subclasses
        //Toda Peca possui 1 das 2 cores: Preto ou Branco

        public int QtdMovimentos { get; protected set; }
        //Ela não entra no construtor pois toda a peça começa sempre com 0 movimentos
        public Tabuleiro Tabuleiro { get; protected set; }
        //Toda a peça está em um tabuleiro

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            Cor = cor;
            Posicao = null; //Posição começa nula (e não recebemos a posição)pois quem qpõe as pessas no tabuleiro é o proprío tabuleiro
            QtdMovimentos = 0; //Toda a peça começa com 0 movimentos
            Tabuleiro = tabuleiro;
        }

        public override string ToString()
        {
            return (
                "Cor: " + Cor + "\n" +
                "Posição: " + Posicao.ToString() + "\n" +
                "Quantidade de Movimentos: " + QtdMovimentos + "\n"
                );
        }

        public void incrementarMovimento()
        {
            QtdMovimentos++;
        }
        public void decrementarMovimento()
        {
            QtdMovimentos--;
        }

        //Aqui nos vamos criar um método que define o moviemnto de cada peça
        //Esse método vai retornar uma matriz de booleanos
        //A matriz representa o tabuleiro
        //Posiçções com true - Posições onde a peça pode se mover
        //Posições com false = Posições onde a peça não pode ser mover

        //A implementação vai depender de cada tipo de peça

        public abstract bool[,] movimentoPeca();
        
        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentoPeca();
            foreach (bool b in mat)
            {
                if(b == true)
                {
                    return true;
                }
            }
            return false;

        }
        

    }
}
