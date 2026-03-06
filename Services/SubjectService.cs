using WebApplication1.DTOs;
using WebApplication1.IRepositories;
using WebApplication1.IServices;

namespace WebApplication1.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _repository;

        public SubjectService(ISubjectRepository repository)
        {
            _repository = repository;
        }

        public async Task InsertSubject(SubjectDtos.InsertSubjectDto dto)
        {
            await _repository.InsertSubject(dto);
        }

        public async Task UpdateSubject(SubjectDtos.UpdateSubjectDto dto)
        {
            await _repository.UpdateSubject(dto);
        }

        public async Task<List<SubjectDtos.SubjectResponseDto>> GetAllSubjects()
        {
            return await _repository.GetAllSubjects();
        }

        public async Task<SubjectDtos.SubjectResponseDto> GetSubjectById(int id)
        {
            return await _repository.GetSubjectById(id);
        }
    }
}
