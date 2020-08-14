using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    class Choice
    {
        public int ChoiceId { get; set; }
        public int QuestionId { get; set; }
        public bool? Correct { get; set; }
        public string ChoiceString { get; set; }
    }
}
