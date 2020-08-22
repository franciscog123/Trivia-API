using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Models
{
    public class QuizQuestion
    {
        public int QuizQuestionId { get; set; }
        [Required]
        public int QuizId { get; set; }
        [Required]
        public int QuestionId { get; set; }
    }
}
