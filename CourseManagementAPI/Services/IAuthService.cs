using CourseManagementAPI.DTOs;
using System.Threading.Tasks;

namespace CourseManagementAPI.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterDto dto);
        Task<string?> LoginAsync(LoginDto dto);
    }
}
