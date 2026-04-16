using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace TodoLibrary.Repos
{
    public class EFTodoRepo : ITodoRepo
    {
        TodoDBContext ctx = new TodoDBContext();

        //Get all tasks
        public async Task<List<Todo>> GetAllTasksAsync()
        {
            List<Todo> tasks = await ctx.Todos.ToListAsync();
            return tasks;
        }

        public async Task<List<Todo>> GetTaskByDateAsync(DateTime date)
        {
            try
            {
                // Filter by StartDate falling on the provided date (UTC/local depends on stored values)
                DateTime dayStart = date.Date;
                DateTime dayEnd = dayStart.AddDays(1);

                var tasks = await ctx.Todos
                    .Where(t => t.StartDate >= dayStart && t.StartDate < dayEnd)
                    .ToListAsync();

                return tasks;
            }
            catch (Exception ex)
            {
                throw new TodoException($"Error retrieving tasks by date: {ex.Message}");
            }
        }
        public async Task<List<Todo>> GetTaskByPriorityAsync(int priority)
        {
            try
            {
                var tasks = await ctx.Todos
                    .Where(t => t.Priority.HasValue && t.Priority.Value == priority)
                    .ToListAsync();

                return tasks;
            }
            catch (Exception ex)
            {
                throw new TodoException($"Error retrieving tasks by priority: {ex.Message}");
            }
        }

        public async Task<List<Todo>> GetTaskByStatusAsync(bool isCompleted)
        {
            try
            {
                // Assumes "Completed" represents completed tasks in the Status column.
                const string completedValue = "Completed";

                List<Todo> tasks;
                if (isCompleted)
                {
                    tasks = await ctx.Todos
                        .Where(t => t.Status == completedValue)
                        .ToListAsync();
                }
                else
                {
                    tasks = await ctx.Todos
                        .Where(t => t.Status != completedValue || t.Status == null)
                        .ToListAsync();
                }

                return tasks;
            }
            catch (Exception ex)
            {
                throw new TodoException($"Error retrieving tasks by status: {ex.Message}");
            }
        }

        public async Task AddTaskAsync(Todo task)
        {
            try
            {
                await ctx.Todos.AddAsync(task);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex) { 
                throw new TodoException(ex.Message);
            }
        }

        public async Task UpdateTaskAsync(Todo task)
        {
            try
            {
                ctx.Todos.Update(task);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex) {
                throw new TodoException(ex.Message);
            }
        }

        public async Task DeleteTaskAsync(Todo task)
        {
            try
            {
                ctx.Todos.Remove(task);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TodoException(ex.Message);
            }
        }
    }
}
