using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyForm.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [ForeignKey(nameof(Question))]
        public int? QuestionId { get; set; }
        public Question Question { get; set; }
        
        [ForeignKey(nameof(Survey))]
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }
    }
}