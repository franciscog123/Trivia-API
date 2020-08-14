using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ApplicationCore.Models
{
    class Question
    {
        public int QuestionId { get; set; }
        public int CategoryId { get; set; }
        public string QuestionString { get; set; }
        public int Value { get; set; }
        public List<Choice> QuestionChoices { get; set; } = new List<Choice>();
        public Category Category { get; set; }
    }
}
