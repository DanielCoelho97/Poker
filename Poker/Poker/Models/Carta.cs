using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poker.Models
{
    public class Carta
    {
        public int naipe;
        public int peso;
        public static List<String> nomes = new List<string>();
        public static List<String> naipes = new List<string>();

        public Carta(int naipe, int peso)
        {
            this.naipe = naipe;
            this.peso = peso;
            nomes = new List<string>();
            naipes = new List<String>();

        }

    }
}
