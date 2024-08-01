using RFToDo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFToDo.Shared.Services
{
    public interface ITaskService
    {
        Task<List<Tasks>> GetTasks(int id);
        Task<string> CreateTask(Tasks task);
        Task<string> UpdateTask(Tasks task);
        Task<string> FinishTask(int id);
        Task<string> ImportanceTask(int id);
        Task<string> DeleteTask(int id);
    }
}
