using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PokemonGame.Pokemon
{
    public class PokemonClient
    {
        static HttpClient client;
        static Pokemon Pmon = new Pokemon();
        public PokemonClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static async Task<Pokemon> GetPokemonAsync(string path)
        {
            var pokemon = "";

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                pokemon = await response.Content.ReadAsStringAsync();
                var yourObject = JsonConvert.DeserializeObject<Pokemon>(pokemon);
                Pmon = Pokemon.FromJson(pokemon);
                Console.WriteLine(Pmon.Name + " " + Pmon.Moves[0].MoveMove.Name);
                return yourObject;
            }
            return null;
        }

        //dirty parameter
        public static async Task GetRandomPokemonAsync(int id,Pokemon Trainer)
        {
            var pokemon = "";

            HttpResponseMessage response = await client.GetAsync("pokemon/"+id.ToString());
            if (response.IsSuccessStatusCode)
            {
                pokemon = await response.Content.ReadAsStringAsync();
                var yourObject = JsonConvert.DeserializeObject<Pokemon>(pokemon);
                Trainer.RandomPokemon = yourObject;
            }
            
        }

        public static async Task<Pokemon> GetStarterPokemon(string path)
        {
            var pokemon = "";

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                pokemon = await response.Content.ReadAsStringAsync();
                var yourObject = JsonConvert.DeserializeObject<Pokemon>(pokemon);
                return yourObject;
            }
            return null;
        }

        public static async Task<Ability> GetAbilitiesAsync(string path, int id)
        {
            Ability abilities = null;

            HttpResponseMessage response = await client.GetAsync(path + "/" + id);
            if (response.IsSuccessStatusCode)
            {
                abilities = await response.Content.ReadAsAsync<Ability>();
            }
            return abilities;
        }

        public static async Task RunAsync()
        {
            client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


            //await GetAbilitiesAsync("ability", 2);
            await GetPokemonAsync("pokemon/ditto");
        }

        //public static void Main()
        //{
        //    Console.WriteLine("Hello World!");

        //    RunAsync().GetAwaiter().GetResult();

        //    Console.ReadKey();
        //}
    }
}

