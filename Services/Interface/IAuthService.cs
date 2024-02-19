using ctrmmvp.DTOs.Auth;
using HotelReviewsAPI.Models.DTO;

namespace ctrmmvp.Services.Interface
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
    }
}