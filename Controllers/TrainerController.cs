using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainerCardBackEnd.Context;
using TrainerCardBackEnd.DTOs;
using TrainerCardBackEnd.Entities;
using TrainerCardBackEnd.Services;

namespace TrainerCardBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainerController : ControllerBase
    {
        private readonly TrainerDataContext _context;
        private readonly AuthService _authService;

        public TrainerController(TrainerDataContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Create(TrainerCreateDto trainerDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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


            _authService.SetPassword(trainer, trainerDto.Password);

            try
            {
                _context.Add(trainer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

            return CreatedAtAction(nameof(Create), new { id = trainer.Id }, trainer);
        }

        [HttpGet("All")]
        public IActionResult GetAllTrainers()
        {

            if (_context.Trainers == null)
                return NoContent();

            var trainers = _context.Trainers.Select(trainer => new TrainerGetDto
            {
                Id = trainer.Id,
                Name = trainer.Name,
                Username = trainer.Username,
                Birth = trainer.Birth,
                Region = trainer.Region,
                City = trainer.City,
                Type = trainer.Type,
                Photo = trainer.Photo,
                MyPokebox = new PokeBoxDto
                {
                    PokemonsIds = trainer.MyPokebox.PokemonsIds
                }
            }).ToList();

            return Ok(trainers);
        }

        [HttpGet("User")]
        public IActionResult GetTrainerByUsername(string username)
        {

            var selectedTrainer = _context.Trainers
                .Include(t => t.MyPokebox)
                .FirstOrDefault(t => t.Username == username);

            if (selectedTrainer == null)
            {
                return NotFound(); ;
            }

            var trainer = new TrainerGetDto
            {
                Name = selectedTrainer.Name,
                Username = selectedTrainer.Username,
                Birth = selectedTrainer.Birth,
                Region = selectedTrainer.Region,
                City = selectedTrainer.City,
                Type = selectedTrainer.Type,
                Photo = selectedTrainer.Photo,
                MyPokebox = selectedTrainer.MyPokebox != null ? new PokeBoxDto
                {
                    PokemonsIds = selectedTrainer.MyPokebox.PokemonsIds
                } : new PokeBoxDto()
            };


            return Ok(trainer);
        }

        [HttpGet("{id}")]
        public IActionResult GetTrainerById(uint id)
        {

            var selectedTrainer = _context.Trainers
                .Include(t => t.MyPokebox)
                .FirstOrDefault(t => t.Id == id);

            if (selectedTrainer == null)
            {
                return NotFound(); ;
            }

            var trainer = new TrainerGetDto
            {
                Name = selectedTrainer.Name,
                Username = selectedTrainer.Username,
                Birth = selectedTrainer.Birth,
                Region = selectedTrainer.Region,
                City = selectedTrainer.City,
                Type = selectedTrainer.Type,
                Photo = selectedTrainer.Photo,
                MyPokebox = selectedTrainer.MyPokebox != null ? new PokeBoxDto
                {
                    PokemonsIds = selectedTrainer.MyPokebox.PokemonsIds
                } : new PokeBoxDto()
            };


            return Ok(trainer);
        }



        [HttpPut("{id}")]
        public IActionResult Update(uint id, TrainerUpdateDto trainerDto)
        {

            var selectedTrainer = _context.Trainers
                .FirstOrDefault(t => t.Id == id);

            if (selectedTrainer == null)
            {
                return NotFound(); ;
            }

            selectedTrainer.Name = trainerDto.Name;
            selectedTrainer.Username = trainerDto.Username;
            selectedTrainer.Birth = trainerDto.Birth;
            selectedTrainer.Password = trainerDto.Password;
            selectedTrainer.Region = trainerDto.Region;
            selectedTrainer.City = trainerDto.City;
            selectedTrainer.Type = trainerDto.Type;
            selectedTrainer.Photo = trainerDto.Photo;

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(uint id)
        {

            var selectedTrainer = _context.Trainers
                .Include(t => t.MyPokebox)
                .FirstOrDefault(t => t.Id == id);

            if (selectedTrainer == null)
            {
                return NotFound(); ;
            }

            _context.Trainers.Remove(selectedTrainer);
            _context.SaveChanges();

            return NoContent();
        }

    }
}