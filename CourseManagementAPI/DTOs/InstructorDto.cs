using System.ComponentModel.DataAnnotations;

namespace CourseManagementAPI.DTOs
{
    public class InstructorCreateDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Bio { get; set; } = string.Empty;

        [MaxLength(200)]
        public string OfficeLocation { get; set; } = string.Empty;
    }

    public class InstructorResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public InstructorProfileDto? Profile { get; set; }
    }

    public class InstructorProfileDto
    {
        public string Bio { get; set; } = string.Empty;
        public string OfficeLocation { get; set; } = string.Empty;
    }
}
