using ctrmmvp.DTOs.Auth;
using HotelReviewsAPI.Models.DTO;

namespace ctrmmvp.Services.Interface
{
    public interface IAuthService
    {
        Task<AcuUserResponse?> GetAcuUserDetails(string name, string token);

        Task<LoginResponse?> LoginAsync(LoginRequest loginRequest); 
    }
}
