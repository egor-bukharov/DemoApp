using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Controllers;
using Demo.DataService;
using Demo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Demo.UnitTests
{
    [TestClass]
    public class TaskControllerUnitTests
    {
        [TestMethod]
        public void GetAllMethodShouldReturnAllRecords()
        {
            var taskDataService = new Mock<ITaskDataService>();

            var random = new Random();
            var tasksCount = random.Next(10, 100);

            var expectedItems = new List<Task>(tasksCount);

            for (var i = 0; i < tasksCount; i++)
            {
                var item = new Task { Name = "Name" + random.Next() };
                expectedItems.Add(item);
            }

            taskDataService.Setup(service => service.GetAll()).Returns(expectedItems);

            var controller = new TaskController(taskDataService.Object);
            var actualItems = controller.Get();

            Assert.AreEqual(expectedItems.Count, actualItems.Count);
            for (var i = 0; i < tasksCount; i++)
            {
                Assert.AreEqual(expectedItems[i].Name, actualItems[i].Name);
            }
        }
    }
}
