using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poker.Models
{
    public class ResultadoJogo
    {
        public List<Carta> cartasJogador1, cartasJogador2;
        public List<String> possiveisMaos;
        public List<String> nomesCartasJogador1, nomesCartasJogador2;
        public List<String> naipesCartasJogador1, naipesCartasJogador2;
        public int maoJogador1, maoJogador2;
        public String resultado;
        private int vencedor;
        public String jogador1 = "Jogador 1", jogador2 = "Jogador 2";
        public String nomeMaoJogador1, nomeMaoJogador2;


        public int defineResultado(int maoJogador1, int maoJogador2)
        {
            if(maoJogador1 > maoJogador2)
            {
                vencedor = 1;               
            }
            else if(maoJogador2 > maoJogador1)
            {
                vencedor = 2;
            }
            else
            {
                vencedor = 3;
            }

            return vencedor;
        }


    }
}
