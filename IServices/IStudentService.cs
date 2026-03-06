using WebApplication1.DTOs;

namespace WebApplication1.IServices
{
    public interface IStudentService
    {
        Task InsertStudent(StudentDtos.InsertStudentDto dto);
        Task UpdateStudent(StudentDtos.UpdateStudentDto dto);
        Task<List<StudentDtos.StudentResponseDto>> GetAllStudents();
        Task<StudentDtos.StudentResponseDto> GetStudentById(int id);
    }
}
