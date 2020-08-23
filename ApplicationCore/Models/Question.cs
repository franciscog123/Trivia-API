using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Models
{
    public class Question
    {
        public int QuestionId { get; set; }

        //nullable int so model validation kicks in if no categoryId provided, instead of defaulting to 0
        [Required]
        public int? CategoryId { get; set; }

        [Required]
        public string QuestionString { get; set; }

        [Required]
        public int Value { get; set; }

        [Required]
        public List<Choice> QuestionChoices { get; set; } = new List<Choice>();
    }
}
