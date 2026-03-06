using WebApplication1.DTOs;

namespace WebApplication1.IServices
{
    public interface ISubjectService
    {
        Task InsertSubject(SubjectDtos.InsertSubjectDto dto);
        Task UpdateSubject(SubjectDtos.UpdateSubjectDto dto);
        Task<List<SubjectDtos.SubjectResponseDto>> GetAllSubjects();
        Task<SubjectDtos.SubjectResponseDto> GetSubjectById(int id);
    }
}
