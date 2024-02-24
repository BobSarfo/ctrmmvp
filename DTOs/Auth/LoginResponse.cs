namespace HotelReviewsAPI.Models.DTO
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string Name { get; set; }
        
        public string? Company { get; set; }
        
        public string? Branch { get; set; } 
    }
}
