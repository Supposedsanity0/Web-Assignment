using CourseManagementAPI.Data;
using CourseManagementAPI.DTOs;
using CourseManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementAPI.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly AppDbContext _context;

        public InstructorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InstructorResponseDto>> GetAllInstructorsAsync()
        {
            return await _context.Instructors
                .AsNoTracking()
                .Select(i => new InstructorResponseDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Profile = i.Profile != null ? new InstructorProfileDto
                    {
                        Bio = i.Profile.Bio,
                        OfficeLocation = i.Profile.OfficeLocation
                    } : null
                })
                .ToListAsync();
        }

        public async Task<InstructorResponseDto?> GetInstructorByIdAsync(int id)
        {
            return await _context.Instructors
                .AsNoTracking()
                .Where(i => i.Id == id)
                .Select(i => new InstructorResponseDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Profile = i.Profile != null ? new InstructorProfileDto
                    {
                        Bio = i.Profile.Bio,
                        OfficeLocation = i.Profile.OfficeLocation
                    } : null
                })
                .FirstOrDefaultAsync();
        }

        public async Task<InstructorResponseDto> CreateInstructorAsync(InstructorCreateDto dto)
        {
            var instructor = new Instructor
            {
                Name = dto.Name,
                Profile = new InstructorProfile
                {
                    Bio = dto.Bio,
                    OfficeLocation = dto.OfficeLocation
                }
            };

            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();

            return await GetInstructorByIdAsync(instructor.Id) ?? new InstructorResponseDto();
        }
    }
}
