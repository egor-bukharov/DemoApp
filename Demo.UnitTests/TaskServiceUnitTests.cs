using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Demo.DataService.SqlServer;
using Demo.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.UnitTests
{
    [TestClass]
    public class TaskServiceUnitTests
    {
        [TestMethod]
        public void GetAllMethodShouldFetchAllRecords()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("Demo");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using (new TransactionScope())
            {
                var random = new Random();

                const int recordsCount = 100;

                var tasks = new List<Task>(recordsCount);
                for (var i = 0; i < recordsCount; i++)
                {
                    var item = new Task { Name = "Name" + random.Next() };
                    tasks.Add(item);
                }

                foreach (var task in tasks)
                {
                    dbContext.Tasks.Add(task);
                }

                dbContext.SaveChanges();

                var tasksDataService = new TaskDataService(dbContext);
                var result = tasksDataService.GetAll();

                Assert.AreEqual(tasks.Count, result.Count);
                
                for (var i = 0; i < recordsCount; i++)
                {
                    var expected = tasks[i];
                    var actual = result[i];

                    Assert.AreNotEqual(expected.Id, 0);
                    Assert.AreEqual(expected.Id, actual.Id);
                    Assert.AreEqual(expected.Name, actual.Name);
                }
            }
        }
    }
}
