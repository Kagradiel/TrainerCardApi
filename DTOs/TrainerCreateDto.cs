using System.ComponentModel.DataAnnotations;

namespace TrainerCardBackEnd.DTOs
{
    public class TrainerCreateDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = default!;

        [Required]
        [StringLength(50)]
        public string Username { get; set; } = default!;

        [Required]
        [StringLength(255)]
        public string Password { get; set; } = default!;

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birth { get; set; }

        [Required]
        public short Region { get; set; }

        [Required]
        public short City { get; set; }

        [Required]
        public short Type { get; set; }

        [Required]
        public byte[] Photo { get; set; } = default!;

        public PokeBoxCreateDto MyPokebox { get; set; } = new PokeBoxCreateDto();
    }
}