namespace CourseManagementAPI.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        
        // One-to-One
        public InstructorProfile? Profile { get; set; }

        // One-to-Many
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
