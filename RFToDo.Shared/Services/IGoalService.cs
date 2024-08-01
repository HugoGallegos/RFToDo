using RFToDo.Shared.DTO;
using RFToDo.Shared.Models;

namespace RFToDo.Shared.Services
{
    public interface IGoalService
    {
        Task<List<Goal>> GetGoals();
        Task<List<GoalDTO>> GetGoalsDTO();
        Task<string> CreateGoal(Goal goal);
        Task<string> UpdateGoal(Goal goal);
        Task<string> DeleteGoal(int id);
    }
}
