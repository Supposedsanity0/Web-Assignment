using System.ComponentModel.DataAnnotations;

namespace CourseManagementAPI.DTOs
{
    public class CourseCreateDto
    {
        [Required, MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required, MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "An instructor must be assigned to the course.")]
        public int InstructorId { get; set; }
    }

    public class CourseUpdateDto
    {
        [Required, MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required, MaxLength(500)]
        public string Description { get; set; } = string.Empty;
    }

    public class CourseResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int InstructorId { get; set; }
        public string InstructorName { get; set; } = string.Empty;
    }
}
