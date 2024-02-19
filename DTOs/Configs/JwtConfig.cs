namespace ctrmmvp.DTOs.Auth
{
    public class JwtConfig
    {
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }
        public string TokenKey { get; set; }
        public int TokenExpiry { get; set; } = 8;
    }
}