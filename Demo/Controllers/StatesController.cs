using System.Collections.Generic;
using Demo.DataService;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    public class StatesController : Controller
    {
        private readonly IStateDataService _stateDataService;

        public StatesController(IStateDataService stateDataService)
        {
            _stateDataService = stateDataService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<State> GetAll()
        {
            return _stateDataService.GetAll();
        }
    }
}
