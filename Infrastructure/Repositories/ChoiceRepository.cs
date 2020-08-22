using ApplicationCore.Interfaces;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ChoiceRepository:IChoiceRepository
    {
        private readonly TriviaGameDBContext _context;

        public ChoiceRepository(TriviaGameDBContext context)
        {
            _context = context;
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

    }
}
