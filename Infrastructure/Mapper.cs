using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ApplicationCore.Models;

namespace Infrastructure
{
    /// <summary>
    /// My custom mapper class.
    /// </summary>
    class Mapper
    {
        public static ApplicationCore.Models.User Map(Entities.User user)
        {
            return new ApplicationCore.Models.User
            {
                Id = user.UserId,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role,
                CreatedDate = user.CreatedDate
            };
        }

        public static Entities.User Map(ApplicationCore.Models.User user)
        {
            return new Entities.User
            {
                UserId = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role,
                CreatedDate = user.CreatedDate
            };
        }

        public static ApplicationCore.Models.Category Map(Entities.Category category)
        {
            return new ApplicationCore.Models.Category
            {
                CategoryId = category.CategoryId,
                CategoryString = category.Category1
            };
        }

        public static Entities.Category Map(ApplicationCore.Models.Category category)
        {
            return new Entities.Category
            {
                CategoryId = category.CategoryId,
                Category1 = category.CategoryString
            };
        }

        public static ApplicationCore.Models.Choice Map(Entities.Choice choice)
        {
            return new ApplicationCore.Models.Choice
            {
                ChoiceId = choice.ChoiceId,
                ChoiceString = choice.Choice1,
                QuestionId = choice.QuestionId,
                Correct = choice.Correct
            };
        }

        public static Entities.Choice Map(ApplicationCore.Models.Choice choice)
        {
            return new Entities.Choice
            {
                ChoiceId = choice.ChoiceId,
                Choice1 = choice.ChoiceString,
                QuestionId = choice.QuestionId,
                Correct = (bool)choice.Correct
            };
        }

        public static ApplicationCore.Models.GameMode Map(Entities.GameMode gameMode)
        {
            return new ApplicationCore.Models.GameMode
            {
                GameModeId = gameMode.GameModeId,
                GameModeString = gameMode.GameMode1
            };
        }

        public static Entities.GameMode Map(ApplicationCore.Models.GameMode gameMode)
        {
            return new Entities.GameMode
            {
                GameModeId = gameMode.GameModeId,
                GameMode1 = gameMode.GameModeString
            };
        }



        public static ApplicationCore.Models.Question Map(Entities.Question question)
        {
            return new ApplicationCore.Models.Question
            {
                QuestionId = question.QuestionId,
                CategoryId = question.CategoryId,
                QuestionString = question.Question1,
                Value = question.Value,
                QuestionChoices = question.Choice.Select(Map).ToList(),
                Category = Map(question.Category)
            };
        }

        public static Entities.Question Map(ApplicationCore.Models.Question question)
        {
            return new Entities.Question
            {
                QuestionId = question.QuestionId,
                CategoryId = question.CategoryId,
                Question1 = question.QuestionString,
                Value = question.Value,
                Choice = question.QuestionChoices.Select(Map).ToList(),
                Category = Map(question.Category)
            };
        }

        public static ApplicationCore.Models.QuizQuestion Map(Entities.QuizQuestion quizQuestion)
        {
            return new ApplicationCore.Models.QuizQuestion
            {
                QuizQuestionId = quizQuestion.QuizQuestionId,
                QuizId = quizQuestion.QuizId,
                QuestionId = quizQuestion.QuestionId
            };
        }

        public static Entities.QuizQuestion Map(ApplicationCore.Models.QuizQuestion quizQuestion)
        {
            return new Entities.QuizQuestion
            {
                QuizQuestionId = quizQuestion.QuizQuestionId,
                QuizId = quizQuestion.QuizId,
                QuestionId = quizQuestion.QuestionId
            };
        }

        public static ApplicationCore.Models.Quiz Map(Entities.Quiz quiz)
        {
            return new ApplicationCore.Models.Quiz
            {
                QuizId = quiz.QuizId,
                UserId = quiz.UserId,
                Category = quiz.Category,
                GameModeId = quiz.GameModeId,
                Score = quiz.Score,
                Time = quiz.Time,
                QuizQuestions = quiz.QuizQuestion.Select(Map).ToList()
            };
        }

        public static Entities.Quiz Map(ApplicationCore.Models.Quiz quiz)
        {
            return new Entities.Quiz
            {
                QuizId = quiz.QuizId,
                UserId = quiz.UserId,
                Category = quiz.Category,
                GameModeId = quiz.GameModeId,
                Score = quiz.Score,
                Time = quiz.Time,
                QuizQuestion = quiz.QuizQuestions.Select(Map).ToList()
            };
        }
    }
}
