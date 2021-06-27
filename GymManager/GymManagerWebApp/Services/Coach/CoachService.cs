using GymManagerWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Models;

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

    }
}
