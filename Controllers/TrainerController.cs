using Microsoft.AspNetCore.Mvc;
using TrainerCardBackEnd.Context;
using TrainerCardBackEnd.DTOs;
using TrainerCardBackEnd.Entities;

namespace TrainerCardBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainerController : ControllerBase
    {
        private readonly TrainerDataContext _context;

        public TrainerController(TrainerDataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(TrainerCreateDto trainerDto)
        {
            var trainer = new Trainer
            {
                Name = trainerDto.Name,
                Username = trainerDto.Username,
                Password = trainerDto.Password,
                Birth = trainerDto.Birth,
                Region = trainerDto.Region,
                City = trainerDto.City,
                Type = trainerDto.Type,
                Photo = trainerDto.Photo,
                MyPokebox = new PokeBox
                {
                    PokemonsIds = trainerDto.MyPokebox.PokemonsIds
                }
            };

            _context.Add(trainer);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterTrainerPorId), new { id = trainer.Id }, trainer);
        }

        [HttpGet]
        public IActionResult ObterTrainerPorId(uint id)
        {

            var trainer = _context.Trainers.Find(id);

            if (trainer == null)
            {
                return NotFound();
            }

            return Ok(trainer);

        }

    }
}