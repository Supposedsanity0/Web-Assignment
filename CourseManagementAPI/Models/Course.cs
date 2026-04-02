namespace CourseManagementAPI.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Foreign Key
        public int InstructorId { get; set; }
        public Instructor? Instructor { get; set; }

        // Many-to-Many
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
