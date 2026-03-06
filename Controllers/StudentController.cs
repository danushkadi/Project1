using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.IServices;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> InsertStudent(StudentDtos.InsertStudentDto dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest("Invalid student data");

                await _service.InsertStudent(dto);

                return StatusCode(201, "Student created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(StudentDtos.UpdateStudentDto dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest("Invalid student data");

                await _service.UpdateStudent(dto);

                return Ok("Student updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var students = await _service.GetAllStudents();

                if (students == null || students.Count == 0)
                    return NotFound("No students found");

                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                var student = await _service.GetStudentById(id);

                if (student == null)
                    return NotFound("Student not found");

                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
