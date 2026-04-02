namespace CourseManagementAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Many-to-Many
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
