using CourseManagementAPI.Data;
using CourseManagementAPI.DTOs;
using CourseManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementAPI.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;

        public CourseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseResponseDto>> GetAllCoursesAsync()
        {
            // LINQ projection and AsNoTracking utilized
            return await _context.Courses
                .AsNoTracking()
                .Select(c => new CourseResponseDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    InstructorId = c.InstructorId,
                    InstructorName = c.Instructor != null ? c.Instructor.Name : ""
                })
                .ToListAsync();
        }

        public async Task<CourseResponseDto?> GetCourseByIdAsync(int id)
        {
            return await _context.Courses
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new CourseResponseDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    InstructorId = c.InstructorId,
                    InstructorName = c.Instructor != null ? c.Instructor.Name : ""
                })
                .FirstOrDefaultAsync();
        }

        public async Task<CourseResponseDto> CreateCourseAsync(CourseCreateDto dto)
        {
            var course = new Course
            {
                Title = dto.Title,
                Description = dto.Description,
                InstructorId = dto.InstructorId
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return await GetCourseByIdAsync(course.Id) ?? new CourseResponseDto();
        }

        public async Task<CourseResponseDto?> UpdateCourseAsync(int id, CourseUpdateDto dto)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return null;

            course.Title = dto.Title;
            course.Description = dto.Description;

            await _context.SaveChangesAsync();

            return await GetCourseByIdAsync(course.Id);
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return false;

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
