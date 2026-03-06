namespace WebApplication1.DTOs
{
    public class StudentDtos
    {
        public class InsertStudentDto
        {
            public string FName { get; set; }
            public string LName { get; set; }
            public DateTime DOB { get; set; }
            public string City { get; set; }
        }

        public class UpdateStudentDto
        {
            public int Id { get; set; }
            public string FName { get; set; }
            public string LName { get; set; }
            public DateTime DOB { get; set; }
            public string City { get; set; }
        }

        public class StudentResponseDto
        {
            public int Id { get; set; }
            public string FName { get; set; }
            public string LName { get; set; }
            public DateTime DOB { get; set; }
            public string City { get; set; }
        }
    }
}
