using System.ComponentModel.DataAnnotations;

namespace Test_ST.Models
{
    public class Form
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public virtual List<Question>? Questions { get; set; }
    }
}
