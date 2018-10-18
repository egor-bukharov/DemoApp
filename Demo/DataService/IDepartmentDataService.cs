using System.Collections.Generic;
using Demo.Models;

namespace Demo.DataService
{
    public interface IDepartmentDataService
    {
        IList<Department> GetAll();

        void Add(Department department);
    }
}
