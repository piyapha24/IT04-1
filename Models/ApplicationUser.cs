using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IT04_1.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(255)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(255)]
        [Required]
        public string LastName { get; set; }

        [StringLength(255)]
        [Required]
        public string Phone { get; set; }

        [Required]
        public string Profile { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }

        [Required]
        public int Occupation { get; set; }

        [Required]
        public bool Sex { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
