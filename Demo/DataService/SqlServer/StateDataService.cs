using System.Collections.Generic;
using System.Linq;
using Demo.Models;

namespace Demo.DataService.SqlServer
{
    public class StateDataService : IStateDataService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public StateDataService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IList<State> GetAll()
        {
            return _applicationDbContext.States
                .OrderBy(department => department.Name)
                .ToList();
        }
    }
}
