using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetQuestionsAsync();
        Task<Question> GetQuestionAsync(int id);
        //Task<Question> AddQuestionAsync(Question question);
        //Task<Question> PutQuestionAsync(int id, Question question);
        //Task<bool> RemoveQuestionAsync(int id);
        //Task<Question> GetRandomQuestion(int categoryId);
    }
}
