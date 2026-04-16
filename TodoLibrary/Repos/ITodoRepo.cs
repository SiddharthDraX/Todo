using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoLibrary.Models;

namespace TodoLibrary.Repos
{
    public interface ITodoRepo
    {
        Task<List<Todo>> GetAllTasksAsync();
        Task<List<Todo>> GetTaskByDateAsync(DateTime date);
        Task<List<Todo>> GetTaskByPriorityAsync(int priority);
        Task<List<Todo>> GetTaskByStatusAsync(bool isCompleted);
        Task AddTaskAsync(Todo task);
        Task UpdateTaskAsync(Todo task);
        Task DeleteTaskAsync(Todo task);
    }
}
