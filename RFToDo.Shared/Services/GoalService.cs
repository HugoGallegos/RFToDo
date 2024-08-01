using Microsoft.EntityFrameworkCore;
using RFToDo.Shared.Data;
using RFToDo.Shared.DTO;
using RFToDo.Shared.Models;

namespace RFToDo.Shared.Services
{
    public class GoalService : IGoalService
    {
        private readonly DataContext _context;

        public GoalService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Goal>> GetGoals()
        {
            var goals = await _context.Goals.ToListAsync();
            return goals;
        }
        public async Task<List<GoalDTO>> GetGoalsDTO()
        {
            var query = from goal in _context.Goals
                        let task = _context.Tasks.Where(x => x.GoalId == goal.Id).ToList()
                        select new GoalDTO()
                        {
                            Goal = goal,
                            TotalTasks= task!=null ? task.Count : 0,
                            CompleteTasks= task!=null ? (task.Where(x => x.Status == true).Count()*100)/ task.Count :0
                        };
            return query.ToList();
        }
        public async Task<string> CreateGoal(Goal goal)
        {
            var goalTemp = _context.Goals.Where(x => x.Name == goal.Name).FirstOrDefaultAsync();
            if (goalTemp != null)
            {
                return "La meta ya existe";
            }
            _context.Goals.Add(goal);
            await _context.SaveChangesAsync();
            if (goal.Id != 0)
            {
                return "Se ha creado la meta";
            }
            else
            {
                return "Ha ocurrido un error";
            }
        }

        public async Task<string> DeleteGoal(int id)
        {
            try
            {
                var _goal = await _context.Goals.FirstOrDefaultAsync(x => x.Id == id);
                if (_goal != null)
                {
                    _context.Attach(_goal).State = EntityState.Detached;
                    _context.Remove(_goal);
                    var result = await _context.SaveChangesAsync();
                    if (result != 0)
                    {
                        return "success";
                    }
                    else
                    {
                        return "error";
                    }
                }
                else
                {
                    return "error";
                }
            }
            catch (Exception ex)
            {
                return "error";
            }
        }

        public async Task<string> UpdateGoal(Goal goal)
        {
            try
            {
                var _goal = await _context.Goals.FirstOrDefaultAsync(x => x.Id == goal.Id);
                if (_goal != null)
                {
                    _context.Attach(_goal).State = EntityState.Detached;
                    _context.Attach(goal).State = EntityState.Modified;
                    var result = await _context.SaveChangesAsync();
                    if (result != 0)
                    {
                        return "success";
                    }
                    else
                    {
                        return "error";
                    }
                }
                else
                {
                    return "error";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "error";
            }
        }
    }
}
