using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonGame.Pokemon
{
    public class GameManager
    {
        
        public static PokemonClient pokemonClient;
        public static Trainer trainer;

        public GameManager()
        {
            pokemonClient = new PokemonClient();
            trainer = new Trainer();
        }

        public static void CalculateDamage(Trainer trainer,Pokemon pokemon,int MoveId)
        {
            int randomIdForPokemon;
            Random rand = new Random();
            randomIdForPokemon = rand.Next(1,pokemon.Moves.Length);
        }
    }
}
