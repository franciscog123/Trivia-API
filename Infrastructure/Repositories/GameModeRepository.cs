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
    public class GameModeRepository:IGameModeRepository
    {
        private readonly TriviaGameDBContext _context;

        public GameModeRepository(TriviaGameDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApplicationCore.Models.GameMode>> GetGameModesAsync()
        {
            List<Entities.GameMode> modes = await _context.GameMode.ToListAsync();

            return modes.Select(Mapper.Map);
        }

        public async Task<ApplicationCore.Models.GameMode> GetGameModeAsync(int id)
        {
            var item = await _context.GameMode.FindAsync(id);

            if (item is null)
                return null;

            return Mapper.Map(item);
        }
    }
}
