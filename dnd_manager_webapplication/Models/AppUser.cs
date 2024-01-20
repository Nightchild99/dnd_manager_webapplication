using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace dnd_manager_webapplication.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(200)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(200)]
        [Required]
        public string LastName { get; set; }

        [StringLength(200)]
        public string? PhotoContentType { get; set; }

        public byte[]? PhotoData { get; set; }
    }
}
