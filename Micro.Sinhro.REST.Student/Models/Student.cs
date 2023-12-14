namespace Micro.Sinhro.REST.Student.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public int? numGrades { get; set; }
        public double? avgGrade { get; set; }


    }
    public class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public double Value { get; set; }
        public DateTime? Date { get; set; }

    }
}
