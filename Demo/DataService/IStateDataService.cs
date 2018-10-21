using System.Collections.Generic;
using Demo.Models;

namespace Demo.DataService
{
    public interface IStateDataService
    {
        IList<State> GetAll();
    }
}
