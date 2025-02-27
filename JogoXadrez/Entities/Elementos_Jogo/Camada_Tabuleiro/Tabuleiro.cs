using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro.Enum;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro.TabuleiroExceptions;

namespace JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        //Quando instanciamos uma amtriz, seu valor inicial é nulo emtodos os valores,caso não seja passado nenhum valor
        private Peca[,] QtdPecas { get; set; }
        //Somente o Tabuleiro mexe nas peças
        //Para darmos acesso as peças, precisamos criar ummétodo

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            QtdPecas = new Peca[linhas, Colunas]; //Recebe uma nova matriz de peças
        }

        //Criamos um método que retorna uma peca em uam determianda posição
        public Peca indentificarPeca(int linha, int coluna)
        {
            return QtdPecas[linha, coluna];
        }

        public Peca indentificarPeca(Posicao pos)
        {
            return QtdPecas[pos.Linha, pos.Coluna];
        }

        public Cor identificarCor(Posicao pos)
        {
            return indentificarPeca(pos).Cor;
        }

        public Cor identificarCor(int linha, int coluna)
        {
            return indentificarPeca(linha,coluna).Cor;
        }



        public void addPeca(Peca peca,Posicao pos)
        {
            //Não precisamos usar um validatePosition, pois este já está implementado em existePéca
            if(existePeca(pos))
            {
                throw new PositionException("Já existe uma peça nesta posição!");
            }
            else
            {
                QtdPecas[pos.Linha, pos.Coluna] = peca;
                peca.Posicao = pos;
            }
        }

        public Peca retirarPeca(Posicao pos)
        {
            if(existePeca(pos))
            {
                Peca aux = indentificarPeca(pos);
                aux.Posicao = null; // Essa linha simboliza que a peça não está em nenhuma posição do tabuleiro
                QtdPecas[pos.Linha, pos.Coluna] = null; //Agora sinalizamos ao tabuleiro que ela foi retirada
                return aux;
            }
            else
            {
                return null;
            }
        }

       
        //Vamos fazer essas funções para adcionar ao método addPeças, para evitar inplementeção de lógicas complexas dentro de outro método

        //Verificar se posiçao é válida
        public bool verifyPosition(Posicao pos)
        {
            if((pos.Linha >= Linhas || pos.Linha < 0) || (pos.Coluna >= Colunas || pos.Coluna < 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool existePeca(Posicao pos)
        {

            validatePosition(pos);

            //antes de fazer essa verificação precisamos saberse a posição passada é valida
            if (indentificarPeca(pos) != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void validatePosition(Posicao pos)
        {
            if(!verifyPosition(pos))
            {
                throw new PositionException("Posição Inválida!");
            }

        }
    }
}
