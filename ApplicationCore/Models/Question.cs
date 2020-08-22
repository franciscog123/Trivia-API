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

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string QuestionString { get; set; }

        [Required]
        public int Value { get; set; }

        [Required]
        public List<Choice> QuestionChoices { get; set; } = new List<Choice>();
    }
}
