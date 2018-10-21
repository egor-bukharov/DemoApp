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
    }
}
