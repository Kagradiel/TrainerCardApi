using Microsoft.AspNetCore.Mvc;
using TrainerCardBackEnd.Context;
using TrainerCardBackEnd.DTOs;

namespace TrainerCardBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokeBoxController : ControllerBase
    {

        private readonly TrainerDataContext _context;

        public PokeBoxController(TrainerDataContext context)
        {
            _context = context;
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePokemons(uint id, PokeBoxDto pokeBoxDto)
        {
            var pokebox = _context.PokeBoxes.FirstOrDefault(p => p.TrainerId == id);

            if (pokebox == null)
                return NotFound();

            pokebox.PokemonsIds = pokeBoxDto.PokemonsIds;

            _context.SaveChanges();

            return Ok();

        }

        [HttpGet("{id}")]
        public IActionResult GetPokemonsByTrainer(uint id)
        {
            var pokeBox = _context.PokeBoxes.FirstOrDefault(p => p.TrainerId == id);

            if (pokeBox == null)
                return NotFound();

            var pokemons = new PokeBoxDto
            {
                PokemonsIds = pokeBox.PokemonsIds
            };

            return Ok(pokemons);
        }

    }
}