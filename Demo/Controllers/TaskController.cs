using System;
using System.Collections.Generic;
using Demo.DataService;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskDataService _taskDataService;

        public TaskController(ITaskDataService taskDataService)
        {
            _taskDataService = taskDataService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IList<Models.Task> Get()
        {
            return _taskDataService.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public Task Post([FromBody] Task task)
        {
            return _taskDataService.Add(task);
        }

        public void Put([FromBody] Task task)
        {

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("new")]
        public Task CreateNew()
        {
            var task = new Task
            {
                Name = "Name",
                CreatedAt = DateTime.Now
            };

            _taskDataService.Add(task);
            return task;
        }
    }
}
