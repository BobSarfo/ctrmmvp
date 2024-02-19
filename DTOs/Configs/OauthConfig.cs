namespace ctrmmvp.DTOs.Auth
{
    public class OauthConfig
    {
        public string Scope { get; set; }
        public string ClientSecret { get; set; }
        public string ClientId { get; set; }
        public string TokenUrl { get; set; }
    }
}