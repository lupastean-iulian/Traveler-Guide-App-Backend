using System.ComponentModel.DataAnnotations;

namespace TravelerGuideApp.API.DTOs
{
    public class UserPutPostDto
    {
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string UserType { get; set; }
    }
}
