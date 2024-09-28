using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainerCardBackEnd.Entities
{
    public class Trainer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; } = default!;

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
        public DateTime Birth { get; set; }

        [Required]
        public short Region { get; set; }

        [Required]
        public short City { get; set; }

        [Required]
        public short Type { get; set; }

        [Required]
        public byte[] Photo { get; set; } = default!;

        public virtual PokeBox MyPokebox { get; set; } = default!;

    }
}