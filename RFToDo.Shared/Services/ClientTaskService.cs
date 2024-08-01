using RFToDo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RFToDo.Shared.Services
{
    public class ClientTaskService:ITaskService
    {
        private readonly HttpClient _httpClient;

        public ClientTaskService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Tasks>> GetTasks(int id)
        {
            var tasks = await _httpClient.GetFromJsonAsync<List<Tasks>>($"api/task/GetTasks/{id}");
            return tasks;
        }
        public async Task<string> CreateTask(Tasks task)
        {
            var result = await _httpClient
               .PostAsJsonAsync("/api/task", task);
            return await result.Content.ReadAsStringAsync();
        }

        public async Task<string> DeleteTask(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/task/{id}");
            return await result.Content.ReadAsStringAsync();
        }

        public async Task<string> FinishTask(int id)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/task/FinishTask/{id}", id);
            return await result.Content.ReadAsStringAsync();
        }


        public async Task<string> ImportanceTask(int id)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/task/ImportanceTask/{id}", id);
            return await result.Content.ReadAsStringAsync();
        }

        public async Task<string> UpdateTask(Tasks task)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/task/{task.Id}", task);
            return await result.Content.ReadAsStringAsync();
        }
    }
}
