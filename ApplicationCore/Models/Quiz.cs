using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Models
{
    public class Quiz
    {
        private int _score;

        public int QuizId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public int GameModeId { get; set; }
        [Required]
        public int Score 
        {
            get => _score;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Score cannot be less than 0", nameof(value));
                }
                _score = value;
            }
        }
        [Required]
        public DateTime Time { get; set; }
        public List<QuizQuestion> QuizQuestions {get; set; }=new List<QuizQuestion>();
    }
}
