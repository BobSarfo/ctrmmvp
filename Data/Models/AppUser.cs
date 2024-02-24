using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ctrmmvp.Data.Models
{
    public class AppUser : IdentityUser
    {
        [Column(TypeName = "varchar(64)")]
        public string? FirstName { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string? LastName { get; set; }

        public string? AcuRefreshToken { get; set; }
        public string? AcuUserId { get; set; }
        public int DefaultBranchId { get; set; }
        public int DefaultCompanyId { get; set; }

        [Column(TypeName = "jsonb")]
        public string? Branch { get; set; }

        [Column(TypeName = "jsonb")]
        public string? Company { get; set; }    
    }
}
