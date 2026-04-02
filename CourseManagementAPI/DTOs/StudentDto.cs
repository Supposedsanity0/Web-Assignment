using System.ComponentModel.DataAnnotations;

namespace CourseManagementAPI.DTOs
{
    public class StudentCreateDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }

    public class StudentResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class EnrollmentCreateDto
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}
