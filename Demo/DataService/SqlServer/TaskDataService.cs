using System.Collections.Generic;
using System.Linq;
using Demo.Models;

namespace Demo.DataService.SqlServer
{
    public class TaskDataService : ITaskDataService
    {
        private readonly ApplicationDbContext _dbContext;

        public TaskDataService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Task> GetAll()
        {
            return _dbContext.Tasks.ToList();
        }

        public Task Add(Task task)
        {
            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();

            return task;
        }

        public Task Edit(Task task)
        {
            var foundTask = _dbContext.Tasks.Single(t => t.Id == task.Id);

            foundTask.Name = task.Name;
            foundTask.Description = task.Description;
            foundTask.CreatedAt = task.CreatedAt;
            foundTask.Completed = task.Completed;
            foundTask.DueDate = task.DueDate;
            foundTask.CompletedAt = task.CompletedAt;

            _dbContext.SaveChanges();

            return foundTask;
        }
    }
}
