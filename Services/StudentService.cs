using WebApplication1.DTOs;
using WebApplication1.IRepositories;
using WebApplication1.IServices;

namespace WebApplication1.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task InsertStudent(StudentDtos.InsertStudentDto dto)
        {
            await _repository.InsertStudent(dto);
        }

        public async Task UpdateStudent(StudentDtos.UpdateStudentDto dto)
        {
            await _repository.UpdateStudent(dto);
        }

        public async Task<List<StudentDtos.StudentResponseDto>> GetAllStudents()
        {
            return await _repository.GetAllStudents();
        }

        public async Task<StudentDtos.StudentResponseDto> GetStudentById(int id)
        {
            return await _repository.GetStudentById(id);
        }
    }
}
