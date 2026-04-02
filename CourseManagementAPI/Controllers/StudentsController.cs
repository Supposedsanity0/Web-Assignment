using CourseManagementAPI.DTOs;
using CourseManagementAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] StudentCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _studentService.CreateStudentAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { }, created);
        }

        [HttpPost("enroll")]
        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Enroll([FromBody] EnrollmentCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var success = await _studentService.EnrollStudentAsync(dto);
            if (!success) return BadRequest("Invalid student or course ID.");

            return Ok("Student enrolled successfully.");
        }
    }
}
