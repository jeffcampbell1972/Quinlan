
namespace Quinlan.Data.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public int GraderId { get; set; }
        public Grader Grader { get; set; }
    }
}
