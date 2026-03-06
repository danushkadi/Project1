using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.IServices;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _service;

        public SubjectController(ISubjectService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> InsertSubject(SubjectDtos.InsertSubjectDto dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest("Invalid subject data");

                await _service.InsertSubject(dto);

                return StatusCode(201, "Subject created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubject(SubjectDtos.UpdateSubjectDto dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest("Invalid subject data");

                await _service.UpdateSubject(dto);

                return Ok("Subject updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubjects()
        {
            try
            {
                var subjects = await _service.GetAllSubjects();

                if (subjects == null || subjects.Count == 0)
                    return NotFound("No subjects found");

                return Ok(subjects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectById(int id)
        {
            try
            {
                var subject = await _service.GetSubjectById(id);

                if (subject == null)
                    return NotFound("Subject not found");

                return Ok(subject);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
