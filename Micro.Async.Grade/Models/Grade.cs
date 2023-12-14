namespace Micro.Async.Grade.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public double Value { get; set; }
        public DateTime? Date { get; set; }

    }
}
