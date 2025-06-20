using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services;

public interface IAuthService
{
    UserModel Authenticate(string username, string password);
}