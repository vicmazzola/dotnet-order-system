using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public class AuthService : IAuthService
    {
        private List<UserModel> _users = new List<UserModel>
        {
            new UserModel { UserId = 1, Username = "operator01", Password = "pass123", Role = "operator" },
            new UserModel { UserId = 2, Username = "analyst01", Password = "pass123", Role = "analyst" },
            new UserModel { UserId = 3, Username = "manager01", Password = "pass123", Role = "manager" },
            new UserModel { UserId = 4, Username = "operator02", Password = "pass123", Role = "operator" },
            new UserModel { UserId = 5, Username = "analyst02", Password = "pass123", Role = "analyst" },
            new UserModel { UserId = 6, Username = "manager02", Password = "pass123", Role = "manager" },
            new UserModel { UserId = 7, Username = "operator03", Password = "pass123", Role = "operator" }
        };

        public UserModel Authenticate(string username, string password)
        {
            // Here you would normally perform a secure password verification
            return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}