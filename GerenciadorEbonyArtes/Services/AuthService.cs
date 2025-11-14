using GerenciadorEbonyArtes.Repositories;

namespace GerenciadorEbonyArtes.Services
{
    public class AuthService
    {
        private readonly userRepository _repo = new userRepository();
        public bool Login(string user, string pass)
        {
            if (string.IsNullOrWhiteSpace(user) ||
            string.IsNullOrWhiteSpace(pass)) 
                return false;

            return _repo.ValidateLogin(user, pass); 
        }
    }
}