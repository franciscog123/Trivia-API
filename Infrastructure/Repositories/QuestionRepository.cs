using ApplicationCore.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
