using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Jogo_Xadrez.RegrasExceptions;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro.Enum;
using JogoXadrez.Entities.Elementos_Jogo.Camada_Tabuleiro.TabuleiroExceptions;

namespace JogoXadrez.Entities.Elementos_Jogo.Camada_Jogo_Xadrez
{
    class PartidaXadrez
    {
        //Criando um atributo do tipo Tabuleiro podemos utilizar seus atributos e metodos aq
        //Sem precisar diretamente mexer nessa classe
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; } //Possivel obter o o vlaor do turno, mas não é possivel altera-lo fora do programa
        public Cor JogadorAtual { get; private set; }
        public bool Finalizada { get; private set; }

        private HashSet<Peca> pecas;

        private HashSet<Peca> pecasCapturadas;

        public bool Xeque { get; private set; }

        public PartidaXadrez()
        {
            Tab = new Tabuleiro(8, 8); //Precisamos de um Tabuleiro para jogar
            Turno = 0; //Jogo começa no turno 0
            JogadorAtual = Cor.Branco; //quem começa a jogar é sempre o branco
            Finalizada = false;
            pecas = new HashSet<Peca>();
            pecasCapturadas = new HashSet<Peca>();
            Xeque = false;
            colocarPecas(); //Quando colocamos ele no construtor, significa que ao iniciarmosum objeto, ele ja vai colocar as peças


        }

        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.retirarPeca(origem);
            p.incrementarMovimento();

            Peca pecaCapturada = Tab.retirarPeca(destino);

            Tab.addPeca(p, destino);
            if (pecaCapturada != null)
            {
                capturarPeca(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void ValidarPosicaoOrigem(Posicao p)
        {
            if (Tab.indentificarPeca(p) == null)
            {
                throw (new JogadaException("Não existem peças nesse campo!"));
            }
            else if (Tab.indentificarPeca(p).existeMovimentosPossiveis() == false)
            {
                throw (new JogadaException("Está pe~ça não possue moviemntos disponíveis!"));
            }
            else if (Tab.identificarCor(p) != JogadorAtual)
            {
                throw (new JogadaException("Não é a sua vez de Jogar! - (Jogador: " + JogadorAtual + ")"));
            }


        }

        public void ValidarPosicaoDestino(Posicao p, bool[,] mat)
        {
            if (Tab.indentificarPeca(p) != null && Tab.identificarCor(p) == JogadorAtual)
            {
                throw (new JogadaException("Você não pode ocupar um espaço já ocupado por outra peça sua!"));
            }
            else if (!(mat[p.Linha, p.Coluna]))
            {
                throw (new JogadaException("A peça escolhida não pode se movimentar para essa posição !"));
            }
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            // 1 - Executa o movimento
            //Caso realizemos um movimento que deixe nosso rei em xeque, movimento deve ser desfeito
            Peca pecaPega = executaMovimento(origem, destino);

            if(existeXeque(JogadorAtual))
            {
                dezfazMovimento(pecaPega, origem, destino);
                throw (new JogadaException("Jogada Inválida! - Jogador em xeque !"));
            }

            if(existeXeque(adversario(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }

            //2 - Passa o Turno
            Turno++;

            // 3 - Troca - Jogador
            mudarJogador();
        }


        /*
         * Toda a Lógica deve estar preferencialmente dentro de uma função
        if (JogadorAtual == Cor.Branco)
        {
            JogadorAtual = Cor.Preto;
        }
        else
        {
            JogadorAtual = Cor.Branco;
        }
        */




        private void dezfazMovimento(Peca pecaCapturada, Posicao origem, Posicao destino)
        {
            Peca p = Tab.retirarPeca(destino);
            p.decrementarMovimento();
            if (pecaCapturada != null)
            {
                Tab.addPeca(pecaCapturada, destino);
                pecasCapturadas.Remove(pecaCapturada);
            }
            Tab.addPeca(p, origem);
        }
        public void mudarJogador()
        {
            if (JogadorAtual == Cor.Branco)
            {
                JogadorAtual = Cor.Preto;
            }
            else
            {
                JogadorAtual = Cor.Branco;
            }
        }

        public static bool verificarMovimento(bool[,] mat, Posicao p)
        {
            return (mat[p.Linha, p.Coluna] == true);
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.addPeca(peca, new PosicaoXadrez(linha, coluna).Convert());
            pecas.Add(peca);
        }

        private void colocarPecas()
        {
            colocarNovaPeca('a', 1, new Torre(Tab, Cor.Branco));
            colocarNovaPeca('b', 1, new Cavalo(Tab, Cor.Branco));
            colocarNovaPeca('c', 1, new Bispo(Tab, Cor.Branco));
            colocarNovaPeca('d', 1, new Dama(Tab, Cor.Branco));
            colocarNovaPeca('e', 1, new Rei(Tab, Cor.Branco, this));
            colocarNovaPeca('f', 1, new Bispo(Tab, Cor.Branco));
            colocarNovaPeca('g', 1, new Cavalo(Tab, Cor.Branco));
            colocarNovaPeca('h', 1, new Torre(Tab, Cor.Branco));
            

            colocarNovaPeca('a', 8, new Torre(Tab, Cor.Preto));
            colocarNovaPeca('b', 8, new Cavalo(Tab, Cor.Preto));
            colocarNovaPeca('c', 8, new Bispo(Tab, Cor.Preto));
            colocarNovaPeca('d', 8, new Dama(Tab, Cor.Preto));
            colocarNovaPeca('e', 8, new Rei(Tab, Cor.Preto, this));
            colocarNovaPeca('f', 8, new Bispo(Tab, Cor.Preto));
            colocarNovaPeca('g', 8, new Cavalo(Tab, Cor.Preto));
            colocarNovaPeca('h', 8, new Torre(Tab, Cor.Preto));
            

        }

        public void capturarPeca(Peca p)
        {
            pecasCapturadas.Add(p);
        }

        public HashSet<Peca> DescobrirPecasCapturadas(Cor cor)
        {
            HashSet<Peca> pecasPegas = new HashSet<Peca>();
            foreach (Peca peca in pecasCapturadas)
            {
                if (peca.Cor == cor)
                {
                    pecasPegas.Add(peca);
                }
            }

            return pecasPegas;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in pecas)
            {
                if (peca.Cor == cor)
                {
                    aux.Add(peca);
                }
            }

            aux.ExceptWith(DescobrirPecasCapturadas(cor));
            return aux;
        }

        public int qtdCapturadas(Cor cor)
        {
            int qtd = 0;
            foreach (Peca peca in pecasCapturadas)
            {
                if (peca.Cor == cor)
                {
                    qtd++;
                }
            }
            return qtd;
        }

        public int qtdEmJogo(Cor cor)
        {
            int qtdTotal = 0;
            int qtdFora = qtdCapturadas(cor);

            foreach (Peca peca in pecas)
            {
                if (peca.Cor == cor)
                {
                    qtdTotal++;
                }
            }

            return (qtdTotal - qtdFora);

        }

        private Cor adversario(Cor cor)
        {
            if (cor == Cor.Branco)
            {
                return Cor.Preto;
            }
            else
            {
                return Cor.Branco;
            }
        }

        private Peca rei(Cor cor)
        {
            foreach (Peca peca in PecasEmJogo(cor))
            {
                if (peca is Rei)
                {
                    return peca;
                }
            }
            return null; //Nunca vai acontecer, a não ser que haja bug
        }

        public bool existeXeque(Cor cor)
        {
            Peca R = rei(cor);
            if (R == null)
            {
                throw new JogadaException("Não tem rei da cor " + cor + " no tabuleiro!");
            }
            foreach (Peca peca in PecasEmJogo(adversario(cor)))
            {
                bool[,] mat = peca.movimentoPeca();
                if (mat[R.Posicao.Linha, R.Posicao.Coluna]) 
                {
                    return true;
                }
            }

            return false;
        }

        /*
        public bool existeXeque(Cor cor)
        {
            foreach(Peca peca in PecasEmJogo(cor))
            {
               bool[,] testeX = peca.movimentoPeca();
               for(int i = 0; i<Tab.Linhas; i++)
                {
                    for(int c = 0; c<Tab.Colunas;c++)
                    {
                        if((Tab.indentificarPeca(i,c) is Rei && Tab.identificarCor(i,c) != JogadorAtual) && testeX[i,c] == true)
                        {
                            return true;
                        }
                    }
                }
                
            }
            return false;
        }

        public void statusXeque(bool teste)
        {
            if(teste == true)
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }

                    
        }
        */


        //--------------------------------------------------------------- Minha Implementação ----------------------------------------------------------------------------------------------------//

        /*
        public void passarTurno()
        {
            Turno++;
        }      
        public void proximoJogador(Cor cor)
        {
            if(cor != null)
            {
                if (!((cor == Cor.Branco && Turno % 2 == 0) || (cor == Cor.Preto && Turno % 2 == 1)))
                {
                    throw (new JogadorException("Jogador já jogou no turno anterior! "));
                }             
            }
            
        }

        public bool verificarJogador(Cor cor)
        {
            if ((cor == Cor.Branco && Turno % 2 == 0) || (cor == Cor.Preto && Turno % 2 == 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        */



    }

}
