using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = Demo.Models.Task;

namespace Demo.DataService
{
    public interface ITaskDataService
    {
        IList<Task> GetAll();
    }
}
