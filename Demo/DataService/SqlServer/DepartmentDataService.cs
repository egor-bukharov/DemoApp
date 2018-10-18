using System.Collections.Generic;
using System.Linq;
using Demo.Models;

namespace Demo.DataService.SqlServer
{
    public class DepartmentDataService : IDepartmentDataService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DepartmentDataService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IList<Department> GetAll()
        {
            return _applicationDbContext.Departments
                .OrderBy(department => department.Name)
                .ToList();
        }

        public void Add(Department department)
        {
            _applicationDbContext.Departments.Add(department);
            _applicationDbContext.SaveChanges();
        }
    }
}
