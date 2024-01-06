using JWTTokenAPI.Models;
using System.Security.Claims;

namespace JWTTokenAPI.Services
{
    public interface IAuthService
    {
        Task<(int, string)> Registeration(RegistrationModel model, string role);
        Task<(int, string)> Login(LoginModel model);

        Task<(int, List<ApplicationUser>)> UserList();
        Task<(int, IList<string>)> UserClaim(string id);
        Task<(int, string)> SetClaims(RolesModel id);
        
    }
}
