using RFToDo.Shared.DTO;
using RFToDo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RFToDo.Shared.Services
{
    public class ClientGoalService : IGoalService
    {
        private readonly HttpClient _httpClient;

        public ClientGoalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Goal>> GetGoals()
        {
            var goals = await _httpClient.GetFromJsonAsync<List<Goal>>("api/goal/GetGoals");
            return goals;
        }
        public async Task<List<GoalDTO>> GetGoalsDTO()
        {
            var goals = await _httpClient.GetFromJsonAsync<List<GoalDTO>>("api/goal/GetGoalsDTO");
            return goals;
        }
        public async Task<string> CreateGoal(Goal goal)
        {
            var result = await _httpClient
                .PostAsJsonAsync("/api/goal", goal);
            return await result.Content.ReadAsStringAsync();
        }

        public async Task<string> DeleteGoal(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/goal/{id}");
            return await result.Content.ReadAsStringAsync();
        }


        public async Task<string> UpdateGoal(Goal goal)
        {
            var result= await _httpClient.PutAsJsonAsync($"api/goal/{goal.Id}", goal);
            return await result.Content.ReadAsStringAsync();
        }
    }
}
