using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PokemonGame.Pokemon
{
    public class PokemonClient
    {
        public static async Task<Pokemon> GetPokemonAsync(int id)
        {
            using (var client = new HttpClient())
            {
                //TODO: throw exception?
                client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var pokemon = "";

                HttpResponseMessage response = await client.GetAsync("pokemon/" + id.ToString());
                if (response.IsSuccessStatusCode)
                {
                    pokemon = await response.Content.ReadAsStringAsync();
                    var yourpokemon = JsonConvert.DeserializeObject<Pokemon>(pokemon);
                    
                    return yourpokemon;
                }

            }
            return null;
        }

        public static async Task InitMovesForPokemon(Pokemon pokemon)
        {
            foreach (Move move in pokemon.Moves)
            {
                var uri = move;

                using (var client = new HttpClient())
                {
                    //do something with http client //9.png
                    client.BaseAddress = new Uri(uri.ToString());
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    var _move = "";


                    HttpResponseMessage response = await client.GetAsync(string.Empty);

                    if (response.IsSuccessStatusCode)
                    {
                        _move = await response.Content.ReadAsStringAsync();
                        Move yourObject = JsonConvert.DeserializeObject<Move>(_move);
                        




                    }
                }
            }
        }

        public static async Task InitMoves(Pokemon pokemon) 
        {
            using (var client = new HttpClient())
            {
                //do something with http client //9.png
                client.BaseAddress = new Uri("https://pokeapi.co/api/v2/move/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var move = "";
                for (int i = 0; i < 6; i++)
                {
                    
                    HttpResponseMessage response = await client.GetAsync(i.ToString());

                    if (response.IsSuccessStatusCode)
                    {
                        move = await response.Content.ReadAsStringAsync();
                        Move yourObject = JsonConvert.DeserializeObject<Move>(move);
                        pokemon.Moves[i].Power = yourObject.Power;
                        pokemon.Moves[i].Name = yourObject.Name;
                    }

                }
                
                

            }
        }

        public static async Task InitMoves(Pokemon pokemon, Pokemon enemyPokemon)
        {
            using (var client = new HttpClient())
            {
                //do something with http client //9.png
                client.BaseAddress = new Uri("https://pokeapi.co/api/v2/move/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var move = "";
                for (int i = 0; i < 6; i++)
                {

                    HttpResponseMessage response = await client.GetAsync(i.ToString());

                    if (response.IsSuccessStatusCode)
                    {
                        move = await response.Content.ReadAsStringAsync();
                        Move yourObject = JsonConvert.DeserializeObject<Move>(move);
                        pokemon.Moves[i].Power = yourObject.Power;
                        pokemon.Moves[i].Name = yourObject.Name;
                        enemyPokemon.Moves[i].Power = yourObject.Power;
                        enemyPokemon.Moves[i].Name = yourObject.Name;
                    }

                }



            }
        }

        public static async Task GetImageForPokemon(Pokemon pokemon)
        {
            using (var client = new HttpClient())
            {
                //do something with http client //9.png
                client.BaseAddress = new Uri("https://pokeres.bastionbot.org/images/pokemon/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var img = "";

                HttpResponseMessage response = await client.GetAsync(pokemon.Id.ToString() + ".png");
                if (response.IsSuccessStatusCode)
                {
                    img = await response.Content.ReadAsStringAsync();
                    pokemon.Image = img;
                }

            }
        }

        //dirty parameter
        public static async Task GetRandomPokemonAsync(Pokemon Trainer)
        {
            var pokemon = "";

            int randomIdForPokemon;
            Random rand = new Random();
            randomIdForPokemon = rand.Next(1, 400);

            using (var client = new HttpClient())
            {
                //TODO: throw exception?
                client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = await client.GetAsync("pokemon/" + randomIdForPokemon.ToString());
                if (response.IsSuccessStatusCode)
                {
                    pokemon = await response.Content.ReadAsStringAsync();
                    var yourObject = JsonConvert.DeserializeObject<Pokemon>(pokemon);
                    Trainer.RandomPokemon = yourObject;
                }

            }
        }

        public static async Task FindEnemyPokemon(Pokemon Trainer)
        {
            var pokemon = "";

            int randomIdForPokemon;
            Random rand = new Random();
            randomIdForPokemon = rand.Next(1, 400);
            
            using (var client = new HttpClient())
            {
                //TODO: throw exception?
                client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = await client.GetAsync("pokemon/" + randomIdForPokemon.ToString());
                if (response.IsSuccessStatusCode)
                {
                    pokemon = await response.Content.ReadAsStringAsync();
                    var yourObject = JsonConvert.DeserializeObject<Pokemon>(pokemon);
                    Trainer.EnemyPokemon = yourObject;
                }

            }
        }



        public static async Task<Pokemon> GetStarterPokemon(string path)
        {
            using (var client = new HttpClient())
            {
                //TODO: throw exception?
                client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var pokemon = "";

                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    pokemon = await response.Content.ReadAsStringAsync();
                    var yourpokemon = JsonConvert.DeserializeObject<Pokemon>(pokemon);
                    return yourpokemon;
                }

            }
            return null;
        }
    }
}

