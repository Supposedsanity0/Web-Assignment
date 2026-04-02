using CourseManagementAPI.DTOs;

namespace CourseManagementAPI.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentResponseDto>> GetAllStudentsAsync();
        Task<StudentResponseDto> CreateStudentAsync(StudentCreateDto dto);
        Task<bool> EnrollStudentAsync(EnrollmentCreateDto dto);
    }
}
