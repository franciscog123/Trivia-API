using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IGameModeRepository
    {
        Task<IEnumerable<GameMode>> GetGameModesAsync();
        Task<GameMode> GetGameModeAsync(int id);
    }
}
