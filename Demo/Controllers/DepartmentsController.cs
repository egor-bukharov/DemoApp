using System;
using System.Collections.Generic;
using Demo.DataService;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentDataService _departmentDataService;

        public DepartmentsController(IDepartmentDataService departmentDataService)
        {
            _departmentDataService = departmentDataService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Department> GetAll()
        {
            return _departmentDataService.GetAll();
        }

        [HttpGet("new")]
        public Department CreateNew()
        {
            var random = new Random();
            var department = new Department
            {
                Name = "Name " + random.Next(),
                Description = "Description " + random.Next()
            };

            _departmentDataService.Add(department);
            return department;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
