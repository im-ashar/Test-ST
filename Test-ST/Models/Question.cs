using System.ComponentModel.DataAnnotations.Schema;

namespace Test_ST.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string? Answer { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<string>? Options { get; set; }

        [ForeignKey(nameof(Form))]
        public int FormId { get; set; }
        public virtual Form? Form { get; set; }
    }
}
