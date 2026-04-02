using CourseManagementAPI.DTOs;

namespace CourseManagementAPI.Services
{
    public interface IInstructorService
    {
        Task<IEnumerable<InstructorResponseDto>> GetAllInstructorsAsync();
        Task<InstructorResponseDto?> GetInstructorByIdAsync(int id);
        Task<InstructorResponseDto> CreateInstructorAsync(InstructorCreateDto dto);
    }
}
