using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonGame.Pokemon
{
    public class Trainer
    {
        public int Id { get; set; }
        public Pokemon selectedPokemon { get; set; }

        public List<Pokemon> pokemons { get; set; }

        public string name { get; set; }

        
    }
}
