using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    interface IQuizRepository
    {
        Task<IEnumerable<Quiz>> GetQuizzesAsync();
        Task<Quiz> AddQuizAsync(Quiz quiz);
    }
}
