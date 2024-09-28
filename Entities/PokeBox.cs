
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainerCardBackEnd.Entities
{
    public class PokeBox
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint BoxId { get; set; }

        public List<int> PokemonsIds { get; set; }

        [ForeignKey("Trainer")]
        public uint TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }

    }
}