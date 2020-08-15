using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class QuizQuestion
    {
        public int QuizQuestionId { get; set; }
        public int QuizId { get; set; }
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
