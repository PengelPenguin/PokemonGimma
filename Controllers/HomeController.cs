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

        public async Task<IActionResult> TrainScreen(int id)
        {
            Pokemon.Pokemon pokemon = await PokemonClient.GetPokemonAsync(id);
            await PokemonClient.FindEnemyPokemon(pokemon);
            await PokemonClient.InitMoves(pokemon);
            return View(pokemon);
        }

        public async Task<IActionResult> GameScreen(int id)
        {
            Pokemon.Pokemon pokemon = await PokemonClient.GetPokemonAsync(id);

            await PokemonClient.GetRandomPokemonAsync(pokemon);
            await PokemonClient.InitMoves(pokemon);
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
