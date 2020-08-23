using ApplicationCore.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class QuestionRepository:IQuestionRepository
    {
        private readonly TriviaGameDBContext _context;

        public QuestionRepository(TriviaGameDBContext context)
        {
            _context = context;
        }

        public async Task<bool> CategoryExistsAsync(int id)
        {
            return await _context.Category.AnyAsync(c => c.CategoryId == id);
        }

        public async Task<bool> QuestionExistsAsync(int id)
        {
            return await _context.Question.AnyAsync(q => q.QuestionId == id);
        }

        public async Task<IEnumerable<ApplicationCore.Models.Question>> GetQuestionsAsync()
        {
            var questions = await _context.Question
                .Include(question => question.Category)
                .Include(question => question.Choice)
                .ToListAsync();

            return questions.Select(Mapper.Map);
        }

        public async Task<ApplicationCore.Models.Question> GetQuestionAsync(int id)
        {
            var item = await _context.Question
                .Include(item => item.Category)
                .Include(item => item.Choice)
                .FirstOrDefaultAsync(item => item.QuestionId == id);

            if (item is null)
                return null;

            return Mapper.Map(item);
        }

        public async Task<ApplicationCore.Models.Question> AddQuestionAsync(ApplicationCore.Models.Question question)
        {
            if (question is null)
            {
                throw new ArgumentNullException(nameof(question));
            }

            Entities.Question entity = Mapper.Map(question);

            await _context.Question.AddAsync(entity);
            await _context.SaveChangesAsync();

            //add questionchoices to db
            foreach (var choice in question.QuestionChoices)
            {
                var coreChoice = new ApplicationCore.Models.Choice {
                    QuestionId = entity.QuestionId,
                    Correct = (bool)choice.Correct,
                    ChoiceString = choice.ChoiceString
                };

                await AddChoiceAsync(coreChoice);
            }

            await _context.SaveChangesAsync();

            return Mapper.Map(entity);
        }

        public async Task<ApplicationCore.Models.Choice> AddChoiceAsync(ApplicationCore.Models.Choice choice)
        {
            if (choice is null)
            {
                throw new ArgumentNullException(nameof(choice));
            }

            Entities.Choice entity = Mapper.Map(choice);

            await _context.Choice.AddAsync(entity);
            await _context.SaveChangesAsync();

            return Mapper.Map(entity);
        }

        public async Task<bool> EditQuestionAsync(ApplicationCore.Models.Question question)
        {
            if(question == null)
            {
                throw new ArgumentException();
            }

            try
            {
                var existing = await _context.Question
                .Include(q => q.Choice)
                .FirstOrDefaultAsync(item => item.QuestionId == question.QuestionId);

                Entities.Question newQuestion = Mapper.MapQuestionWithChoices(question);
                _context.Entry(existing).CurrentValues.SetValues(newQuestion);

                //add choices if they don't exist, or update them if they exist
                foreach (var choice in question.QuestionChoices)
                {
                    var existingChoice =  existing.Choice
                        .FirstOrDefault(c => c.ChoiceId == choice.ChoiceId);

                    if(existingChoice == null)
                    {
                        existing.Choice.Add(Mapper.MapChoiceWithoutId(choice));
                    }
                    else
                    {
                        _context.Entry(existingChoice).CurrentValues.SetValues(Mapper.Map(choice));
                    }
                }

                //delete choices not included in request but still in DB
                foreach(var choice in existing.Choice)
                {
                    if(!question.QuestionChoices.Any(c => c.ChoiceId == choice.ChoiceId))
                    {
                        _context.Remove(choice);
                    }
                }

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

    }
}
