namespace TrainerCardBackEnd.DTOs
{
    public class TrainerGetDto
    {
        public uint Id { get; set; } = default!;

        public string Name { get; set; } = default!;

        public string Username { get; set; } = default!;

        public DateTime Birth { get; set; }

        public short Region { get; set; }

        public short City { get; set; }

        public short Type { get; set; }

        public byte[] Photo { get; set; } = default!;

        public PokeBoxDto MyPokebox { get; set; } = new PokeBoxDto();
    }
}