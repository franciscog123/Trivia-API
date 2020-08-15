using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Infrastructure.Context;
using ApplicationCore.Models;
using System.Linq;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly TriviaGameDBContext _context;

        public UserRepository(TriviaGameDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApplicationCore.Models.User>> GetUsersAsync()
        {
            List<Entities.User> users = await _context.User.ToListAsync();

            return users.Select(Mapper.Map);

        }
    }
}
