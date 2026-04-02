namespace CourseManagementAPI.Models
{
    public class InstructorProfile
    {
        public int Id { get; set; }
        public string Bio { get; set; } = string.Empty;
        public string OfficeLocation { get; set; } = string.Empty;

        // Foreign Key
        public int InstructorId { get; set; }
        public Instructor? Instructor { get; set; }
    }
}
