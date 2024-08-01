using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RFToDo.Shared.Data;
using RFToDo.Shared.DTO;
using RFToDo.Shared.Models;
using RFToDo.Shared.Services;

namespace RFToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly IGoalService _goalService;

        public GoalController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        [HttpGet("GetGoals")]
        public async Task<ActionResult<List<Goal>>> GetGoals()
        {
            var goals = await _goalService.GetGoals();
            return  goals;
        }
        [HttpGet("GetGoalsDTO")]
        public async Task<ActionResult<List<GoalDTO>>> GetGoalsDTO()
        {
            var goals = await _goalService.GetGoalsDTO();
            return goals;
        }
        [HttpPost("CreateGoal")]
        public async Task<ActionResult<Goal>> CreateGoal(Goal goal)
        {
            var addedGoal = await _goalService.CreateGoal(goal);
            return Ok(addedGoal);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<string>> DeleteGoal(int id)
        {
            var deletedGoal= await _goalService.DeleteGoal(id);
            return deletedGoal;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateGoal(Goal goal)
        {
            var updatedGoal= await _goalService.UpdateGoal(goal);
            return Ok(updatedGoal);
        }
    }
}
