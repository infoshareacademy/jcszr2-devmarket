using GymManagerWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagerWebApp.Services.CoachService
{
    public class CoachService : ICoachService
    {
        private readonly GymManagerContext _dbContext;


        public CoachService(GymManagerContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task AddCoachAsync(string coachName, string coachSurName)
        {
            var coachToAdd = new Coach(coachName, coachSurName);
            await _dbContext.Coaches.AddAsync(coachToAdd);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Coach>> GetAllCoaches()
        {
           var list = await _dbContext.Coaches.Select(x => x).ToListAsync();
           return list;
        }

    }
}
