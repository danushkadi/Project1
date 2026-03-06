namespace WebApplication1.DTOs
{
    public class SubjectDtos
    {
        public class InsertSubjectDto
        {
            public string SubjectName { get; set; }
        }

        public class UpdateSubjectDto
        {
            public int SubjectId { get; set; }
            public string SubjectName { get; set; }
        }

        public class SubjectResponseDto
        {
            public int SubjectId { get; set; }
            public string SubjectName { get; set; }
        }
    }
}
