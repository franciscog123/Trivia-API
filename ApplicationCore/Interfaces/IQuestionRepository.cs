using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetQuestionsAsync();
        Task<Question> GetQuestionAsync(int id);
        Task<Question> AddQuestionAsync(Question question);
        Task<ApplicationCore.Models.Choice> AddChoiceAsync(ApplicationCore.Models.Choice choice);
        Task<bool> QuestionExistsAsync(int id);
        Task<bool> CategoryExistsAsync(int id);
        Task<bool> EditQuestionAsync(Question question);
        Task<bool> RemoveQuestionAsync(int id);
        //Task<Question> GetRandomQuestion(int categoryId);
    }
}
