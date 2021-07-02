using GymManagerWebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Services.Exercises
{
    public class ExercisesService : IExercisesService
    {

        private readonly GymManagerContext _dbContext;

        public ExercisesService(GymManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

       public async Task<List<Exercise>> GetAllExercises ()
        {
            var exercises = await _dbContext.ListOfExercises.Select(x => x).ToListAsync();
            return exercises;
        }
    }
}
