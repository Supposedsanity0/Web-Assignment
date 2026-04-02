using System.ComponentModel.DataAnnotations;

namespace CourseManagementAPI.DTOs
{
    public class RegisterDto
    {
        [Required, MaxLength(50)]
        public string Username { get; set; } = string.Empty;
        
        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "Student"; // Admin, Instructor, Student
    }

    public class LoginDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
