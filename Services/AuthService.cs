using TrainerCardBackEnd.Entities;

namespace TrainerCardBackEnd.Services
{
    public class AuthService
    {
        public void SetSenha(Trainer trainer, string password)
        {
            trainer.Password = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerificarSenha(Trainer trainer, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, trainer.Password);
        }
    }
}