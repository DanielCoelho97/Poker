using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poker.Models
{
    public class Main
    {
        Carta a = new Carta(1, 13);

        internal ResultadoJogo startGame()
        {
            ResultadoJogo jogo = new ResultadoJogo();

            jogo.possiveisMaos = new List<String>();

            jogo.possiveisMaos.Add("High Card");//0
            jogo.possiveisMaos.Add("One Pair");//1
            jogo.possiveisMaos.Add("Two Pair");//2
            jogo.possiveisMaos.Add("Three of a Kind");//3
            jogo.possiveisMaos.Add("Straight");//4
            jogo.possiveisMaos.Add("Flush");//5
            jogo.possiveisMaos.Add("Full House");//6
            jogo.possiveisMaos.Add("Four of a Kind");//7
            jogo.possiveisMaos.Add("Straight Flush");//8
            jogo.possiveisMaos.Add("Royal Flush");//9

            jogo.cartasJogador1 = new List<Carta>();
            jogo.cartasJogador2 = new List<Carta>();

            jogo.cartasJogador1 = defineCartasJogador(jogo.cartasJogador1);
            jogo.cartasJogador2 = defineCartasJogador(jogo.cartasJogador2);

            Carta.nomes.Add("Dois");//0
            Carta.nomes.Add("Três");//1
            Carta.nomes.Add("Quatro");//2
            Carta.nomes.Add("Cinco");//3
            Carta.nomes.Add("Seis");//4
            Carta.nomes.Add("Sete");//5
            Carta.nomes.Add("Oito");//6
            Carta.nomes.Add("Nove");//7
            Carta.nomes.Add("Dez");//8
            Carta.nomes.Add("Valete");//9
            Carta.nomes.Add("Dama");//10
            Carta.nomes.Add("Rei");//11
            Carta.nomes.Add("Ás");//12

            Carta.naipes.Add("Ouros");//0
            Carta.naipes.Add("Paus");//1
            Carta.naipes.Add("Espadas");//2
            Carta.naipes.Add("Copas");//3

            jogo.maoJogador1 = defineMao(jogo.cartasJogador1);
            jogo.maoJogador2 = defineMao(jogo.cartasJogador2);

            int vencedor = jogo.defineResultado(jogo.maoJogador1, jogo.maoJogador2);

            jogo.nomesCartasJogador1 = new List<string>();
            jogo.nomesCartasJogador2 = new List<string>();
            jogo.naipesCartasJogador1 = new List<string>();
            jogo.naipesCartasJogador2 = new List<string>();

            for (int i = 0; i <= 4; i++)
            {
                jogo.nomesCartasJogador1.Add(Carta.nomes[jogo.cartasJogador1[i].peso] + " de " +
                   Carta.naipes[jogo.cartasJogador1[i].naipe]);
                //jogo.naipesCartasJogador1.Add(Carta.naipes[jogo.cartasJogador1[i].naipe]);

                jogo.nomesCartasJogador2.Add(Carta.nomes[jogo.cartasJogador2[i].peso] + " de " +
                   Carta.naipes[jogo.cartasJogador2[i].naipe]);
                //jogo.naipesCartasJogador2.Add(Carta.naipes[jogo.cartasJogador2[i].naipe]);
            }

            if (vencedor == 1 || vencedor == 2)
            {
                jogo.resultado = "O jogador " + vencedor + " venceu!!!";
            }
            else
            {
                jogo.resultado = "Deu empate!!!";
            }

            jogo.nomeMaoJogador1 = jogo.possiveisMaos[jogo.maoJogador1];
            jogo.nomeMaoJogador2 = jogo.possiveisMaos[jogo.maoJogador2];

            return jogo;
        }


        private List<Carta> defineCartasJogador(List<Carta> cartasJogador)
        {
            Random num = new Random();
            int contador = 0;
            List<int> apoioPeso = new List<int>();
            List<int> apoioNaipe = new List<int>();

            for (int i = 0; i <= 4; i++)
            {
                apoioPeso.Add(num.Next(0, 13));
                apoioNaipe.Add(num.Next(0, 4));

                if (i > 0)
                {
                    if (apoioPeso[i] == apoioPeso[i - 1])
                    {
                        contador++;
                    }

                }

            }

            apoioPeso.Sort();

            if (contador == 4)// entrará nesse "if" caso tenham sido selecionadas 5 cartas de msm peso para um jogador
            {
                int x = apoioPeso[0];
                Random n = new Random();

                while (apoioPeso[0] == x)
                {
                    apoioPeso[0] = n.Next(0, 13);
                }
            }

            int h = -1, y = -1, z = -1;

            for(int i = 1; i <= 4; i++)// os dois "for" juntos testam pra ver se existem cartas
                                       // de mesmo valor e naipe ao mesmo tempo e caso haja
                                       //corrige esse erro
            {
                for(int j = i-1; j >= 0; j--)
                {
                    if(apoioPeso[i] == apoioPeso[j])
                    {
                        if(apoioNaipe[i] == apoioNaipe[j])
                        {
                            if(h == -1)
                            {
                                h = apoioNaipe[j];
                            }
                            else
                            {
                                if(y == -1)
                                {
                                    y = apoioNaipe[j];
                                }
                                else
                                {
                                    if(z == -1)
                                    {
                                        z = apoioNaipe[j];
                                    }
                                }
                            }
                        }
                    }
                }

                while (apoioNaipe[i] == h || apoioNaipe[i] == y || apoioNaipe[i] == z)
                {
                    Random numero = new Random();
                    apoioNaipe[i] = numero.Next(0, 4);
                }

                h = -1;
                y = -1;
                z = -1;

            }
           
            for (int j = 0; j <= 4; j++)
            {
                Carta apoio = new Carta(apoioNaipe[j], apoioPeso[j]);
                cartasJogador.Add(apoio);
            }

            return cartasJogador;
        }

        private int defineMao(List<Carta> cartasJogador)
        {
            ResultadoJogo jogo = new ResultadoJogo();
            int maoJogador = 0;

            int naipe = cartasJogador[0].naipe;//pegando o naipe da primeira carta

            if (naipe.Equals(cartasJogador[1].naipe) && naipe.Equals(cartasJogador[2].naipe)
                && naipe.Equals(cartasJogador[3].naipe) && naipe.Equals(cartasJogador[4].naipe))
            {//caso seja falso, a mão não será nenhum tipo de flush
                int pesoAtual;
                int contadorSequencia = 0;

                for (int i = 0; i <= 3; i++)
                {
                    pesoAtual = cartasJogador[i].peso;

                    if (cartasJogador[i + 1].peso != pesoAtual + 1)
                    {
                        contadorSequencia++;
                    }
                }

                if (contadorSequencia == 0)
                {
                    if (cartasJogador[0].peso == 8)// se a primeira carta for um 10, a mão só poderá ser um royal flush
                    {
                        maoJogador = 9; // Royal Flush
                    }
                    else
                    {
                        maoJogador = 8; // Straight Flush
                    }
                }
                else
                {
                    int contador = 0;

                    for (int i = 1; i <= 4; i++)
                    {
                        if (cartasJogador[i - 1].peso == cartasJogador[i].peso)// como as cartas estarao em ordem crescente 
                                                                               // de valor de peso, cartas de mesmo peso
                                                                               //estao sempre juntas
                        {
                            contador++;
                        }
                    }

                    if (contador == 3)
                    {
                        maoJogador = 7; // Four of a kind
                    }
                    else
                    {
                        if (contador != 3)
                        {
                            contador = 0;
                            int contadoraux = 0;
                            int auxiliar = cartasJogador[0].peso;

                            for (int i = 1; i <= 4; i++)
                            {
                                if (auxiliar == cartasJogador[i].peso)
                                {
                                    contador++;
                                }
                                else
                                {
                                    if (cartasJogador[i - 1].peso == cartasJogador[i].peso)
                                    {
                                        contadoraux++;
                                    }
                                }
                            }

                            if ((contador == 2 && contadoraux == 1) || (contador == 1 && contadoraux == 2))
                            {
                                maoJogador = 6; // Full House
                            }

                            else
                            {
                                maoJogador = 5; // Flush
                            }

                        }

                    }
                }

            }
            else   //fecha os flushs
            {
                int contadorSequencia2 = 0, contadorTripla = 0, contadorDupla = 0;


                for (int i = 1; i <= 4; i++)
                {
                    if (cartasJogador[i - 1].peso + 1 == cartasJogador[i].peso)
                    {
                        contadorSequencia2++;
                    }

                    if (i < 4)
                    {
                        if (cartasJogador[i - 1].peso == cartasJogador[i].peso && cartasJogador[i].peso ==
                                cartasJogador[i + 1].peso)
                        {
                            contadorTripla++;
                        }
                    }

                    if (cartasJogador[i - 1].peso == cartasJogador[i].peso)
                    {
                        contadorDupla++;
                    }

                }// fecha o for

                if (contadorSequencia2 == 4)
                {
                    maoJogador = 4; //Straight
                }
                else
                {
                    if (contadorTripla == 1)
                    {
                        maoJogador = 3; // Three of a kind
                    }
                    else
                    {
                        if (contadorDupla == 2)
                        {
                            maoJogador = 2; // Two Pair
                        }
                        else
                        {
                            if (contadorDupla == 1)
                            {
                                maoJogador = 1; // One pair
                            }
                            else
                            {
                                maoJogador = 0; // High Card
                            }

                        }
                    }
                }
            }

            return maoJogador;
        }

    }
}
