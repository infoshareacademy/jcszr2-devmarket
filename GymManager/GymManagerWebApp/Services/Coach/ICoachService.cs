using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Services.CoachService
{
    public interface ICoachService
    {
        Task AddCoachAsync(string coachName, string coachSurName);
    }
}
