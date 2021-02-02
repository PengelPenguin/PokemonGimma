using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PokemonGame.Models;
using PokemonGame.Pokemon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PokemonGame.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        PokemonClient pokemonClient;
        public HomeController(ILogger<HomeController> logger)
        {
            pokemonClient = new PokemonClient();
            _logger = logger;
        }

        public async Task<IActionResult> Index1()
        {
            Pokemon.Pokemon pokemon = await PokemonClient.GetPokemonAsync("pokemon/mankey");
            return View(pokemon);
        }

        public async Task<IActionResult> ChooseStarter()
        {
            //Pokemon.Pokemon pokemon = await PokemonClient.GetPokemonAsync("pokemon/mankey");
            List<Pokemon.Pokemon> pokemons = new List<Pokemon.Pokemon>();
            Pokemon.Pokemon pokemon1 = await PokemonClient.GetStarterPokemon("pokemon/charmander");
            Pokemon.Pokemon pokemon2 = await PokemonClient.GetStarterPokemon("pokemon/squirtle");
            Pokemon.Pokemon pokemon3 = await PokemonClient.GetStarterPokemon("pokemon/bulbasaur");
            pokemons.Add(pokemon1);
            pokemons.Add(pokemon2);
            pokemons.Add(pokemon3);

            return View(pokemons);
        }

        public async Task<IActionResult> GameScreen(int id)
        {
            using (var client = new HttpClient())
            {
                //do something with http client
                client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

            }
            Pokemon.Pokemon pokemon = await PokemonClient.GetPokemonAsync("pokemon/" + id.ToString());

            int randomIdForPokemon;
            Random rand = new Random();
            randomIdForPokemon = rand.Next(1, 400);

            using (var client = new HttpClient())
            {
                //do something with http client //9.png
                client.BaseAddress = new Uri("https://pokeres.bastionbot.org/images/pokemon/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var img = "";

                HttpResponseMessage response = await client.GetAsync(id.ToString()+".png");
                if (response.IsSuccessStatusCode)
                {
                    img = await response.Content.ReadAsStringAsync();
                    pokemon.Image = img;
                }

            }

            await PokemonClient.GetRandomPokemonAsync(randomIdForPokemon, pokemon);
            return View(pokemon);
        }

        
        public async Task<IActionResult> Index()
        {
            //Pokemon.Pokemon pokemon = await PokemonClient.GetPokemonAsync("pokemon/mankey");
            List<Pokemon.Pokemon> pokemons = new List<Pokemon.Pokemon>();
            Pokemon.Pokemon pokemon1 = await PokemonClient.GetStarterPokemon("pokemon/charmander");
            Pokemon.Pokemon pokemon2 = await PokemonClient.GetStarterPokemon("pokemon/squirtle");
            Pokemon.Pokemon pokemon3 = await PokemonClient.GetStarterPokemon("pokemon/bulbasaur");
            pokemons.Add(pokemon1);
            pokemons.Add(pokemon2);
            pokemons.Add(pokemon3);

            return View(pokemons);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
