using System.ComponentModel.DataAnnotations.Schema;
using Test_ST.Models;

namespace Test_ST.ViewModels
{
    public class QuestionRequest
    {
        public string Text { get; set; }
        public string? Answer { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<string>? Options { get; set; }
        public int FormId { get; set; }
    }
}
