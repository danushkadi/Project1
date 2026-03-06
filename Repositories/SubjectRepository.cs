using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.IRepositories;

namespace WebApplication1.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _context;

        public SubjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertSubject(SubjectDtos.InsertSubjectDto dto)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC insertsubject @SubjectName",
                new SqlParameter("@SubjectName", dto.SubjectName)
            );
        }

        public async Task UpdateSubject(SubjectDtos.UpdateSubjectDto dto)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC updatesubject @SubjectId, @SubjectName",
                new SqlParameter("@SubjectId", dto.SubjectId),
                new SqlParameter("@SubjectName", dto.SubjectName)
            );
        }

        public async Task<List<SubjectDtos.SubjectResponseDto>> GetAllSubjects()
        {
            return await _context.Set<SubjectDtos.SubjectResponseDto>()
                .FromSqlRaw("EXEC getallsubjects")
                .ToListAsync();
        }

        public async Task<SubjectDtos.SubjectResponseDto> GetSubjectById(int id)
        {
            var result = await _context.Set<SubjectDtos.SubjectResponseDto>()
                .FromSqlRaw("EXEC getsubjectbyid @SubjectId",
                new SqlParameter("@SubjectId", id))
                .ToListAsync();

            return result.FirstOrDefault();
        }
    }
}
