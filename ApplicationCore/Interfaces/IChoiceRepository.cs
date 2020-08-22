using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IChoiceRepository
    {
        Task<ApplicationCore.Models.Choice> AddChoiceAsync(ApplicationCore.Models.Choice choice);
    }
}
