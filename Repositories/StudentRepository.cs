using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.IRepositories;

namespace WebApplication1.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertStudent(StudentDtos.InsertStudentDto dto)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC insertstudent @FName, @LName, @DOB, @City",
                new SqlParameter("@FName", dto.FName),
                new SqlParameter("@LName", dto.LName),
                new SqlParameter("@DOB", dto.DOB),
                new SqlParameter("@City", dto.City)
            );
        }

        public async Task UpdateStudent(StudentDtos.UpdateStudentDto dto)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC updatestudent @Id, @FName, @LName, @DOB, @City",
                new SqlParameter("@Id", dto.Id),
                new SqlParameter("@FName", dto.FName),
                new SqlParameter("@LName", dto.LName),
                new SqlParameter("@DOB", dto.DOB),
                new SqlParameter("@City", dto.City)
            );
        }

        public async Task<List<StudentDtos.StudentResponseDto>> GetAllStudents()
        {
            return await _context.Set<StudentDtos.StudentResponseDto>()
                .FromSqlRaw("EXEC getallstudents")
                .ToListAsync();
        }

        public async Task<StudentDtos.StudentResponseDto> GetStudentById(int id)
        {
            var result = await _context.Set<StudentDtos.StudentResponseDto>()
                .FromSqlRaw("EXEC getstudentbyid @Id",
                new SqlParameter("@Id", id))
                .ToListAsync();

            return result.FirstOrDefault();
        }
    }
}
