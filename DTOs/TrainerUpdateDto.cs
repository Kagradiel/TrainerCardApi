using System.ComponentModel.DataAnnotations;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace TrainerCardBackEnd.DTOs
{
    public class TrainerUpdateDto
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
        [RegularExpression(@"^\d{2}/\d{2}/\d{4}$", ErrorMessage = "Data deve estar no formato dd/MM/yyyy")]
        public DateTime Birth { get; set; }

        [Required]
        public short Region { get; set; }

        [Required]
        public short City { get; set; }

        [Required]
        public short Type { get; set; }

        [Required]
        public byte[] Photo { get; set; } = default!;

    }
}