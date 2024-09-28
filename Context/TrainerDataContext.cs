
using Microsoft.EntityFrameworkCore;
using TrainerCardBackEnd.Entities;

namespace TrainerCardBackEnd.Context
{
    public class TrainerDataContext : DbContext
    {
        public TrainerDataContext(DbContextOptions<TrainerDataContext> options) : base(options)
        {

        }

        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<PokeBox> PokeBoxes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trainer>()
                .HasOne(t => t.MyPokebox)
                .WithOne(p => p.Trainer)
                .HasForeignKey<PokeBox>(p => p.TrainerId);
        }


    }
}