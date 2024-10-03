using TrainerCardBackEnd.Entities;

namespace TrainerCardBackEnd.Services
{
    public class AuthService
    {
        public void SetPassword(Trainer trainer, string password)
        {
            trainer.Password = BCrypt.Net.BCrypt.HashPassword(password);
            Console.WriteLine(trainer.Password);
        }

        public bool VerifyPassword(Trainer trainer, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, trainer.Password);
        }
    }
}