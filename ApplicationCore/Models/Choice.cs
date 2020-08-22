using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Models
{
    public class Choice
    {
        public int ChoiceId { get; set; }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public bool? Correct { get; set; }
        [Required]
        public string ChoiceString { get; set; }
    }
}
