using Microsoft.EntityFrameworkCore;
using RFToDo.Shared.Data;
using RFToDo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFToDo.Shared.Services
{
    public class TaskService : ITaskService
    {
        private readonly DataContext _context;

        public TaskService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Tasks>> GetTasks(int id)
        {
            var tasks = await _context.Tasks.Where(x=>x.GoalId==id).ToListAsync();
            return tasks;
        }
        public async Task<string> CreateTask(Tasks task)
        {
            var taskTemp = _context.Tasks.Where(x => x.Name == task.Name).FirstOrDefault();
            if (taskTemp != null)
            {
                return "La tarea ya existe";
            }
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            if (task.Id != 0)
            {
                return "Se haa creado la tarea";
            }
            else
            {
                return "Ha ocurrido un error";
            }
        }

        public async Task<string> DeleteTask(int id)
        {
            try
            {
                var _task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
                if (_task != null)
                {
                    _context.Attach(_task).State = EntityState.Detached;
                    _context.Remove(_task);
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

        public async Task<string> FinishTask(int id)
        {
            try
            {
                var _task= await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
                if (_task != null)
                {
                    _context.Attach(_task).State = EntityState.Detached;
                    _task.Status = true;
                    _context.Attach(_task).State = EntityState.Modified;
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


        public async Task<string> ImportanceTask(int id)
        {
            try
            {
                var _task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
                if (_task != null)
                {
                    _context.Attach(_task).State = EntityState.Detached;
                    _task.Importance = _task.Importance!;
                    _context.Attach(_task).State = EntityState.Modified;
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

        public async Task<string> UpdateTask(Tasks task)
        {
            try
            {
                var _task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == task.Id);
                if (_task != null)
                {
                    _context.Attach(_task).State = EntityState.Detached;
                    _context.Attach(task).State = EntityState.Modified;
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
