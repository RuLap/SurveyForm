using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurveyForm.Models
{
    public class Survey
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime SubmitTime { get; set; }

        [Required]
        public Guid UserId { get; set; }
        
        public ICollection<Question> Questions { get; set; }
    }
}