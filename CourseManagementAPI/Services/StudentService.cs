using CourseManagementAPI.Data;
using CourseManagementAPI.DTOs;
using CourseManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentResponseDto>> GetAllStudentsAsync()
        {
            return await _context.Students
                .AsNoTracking()
                .Select(s => new StudentResponseDto
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToListAsync();
        }

        public async Task<StudentResponseDto> CreateStudentAsync(StudentCreateDto dto)
        {
            var student = new Student
            {
                Name = dto.Name
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return new StudentResponseDto { Id = student.Id, Name = student.Name };
        }

        public async Task<bool> EnrollStudentAsync(EnrollmentCreateDto dto)
        {
            var studentExists = await _context.Students.AnyAsync(s => s.Id == dto.StudentId);
            var courseExists = await _context.Courses.AnyAsync(c => c.Id == dto.CourseId);

            if (!studentExists || !courseExists) return false;

            var enrollment = new Enrollment
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId
            };

            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
