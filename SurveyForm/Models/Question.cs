using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurveyForm.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }
        
        [Required]
        public AnswerType AnswerType { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}