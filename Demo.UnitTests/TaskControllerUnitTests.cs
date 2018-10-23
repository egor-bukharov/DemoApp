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
        private Mock<ITaskDataService> _taskDataService;

        [TestInitialize]
        public void TestInitialize()
        {
            _taskDataService = new Mock<ITaskDataService>();
        }

        [TestMethod]
        public void GetAllMethodShouldReturnAllRecords()
        {
            var random = new Random();
            var tasksCount = random.Next(10, 100);

            var expectedItems = new List<Task>(tasksCount);

            for (var i = 0; i < tasksCount; i++)
            {
                var item = new Task { Name = "Name" + random.Next() };
                expectedItems.Add(item);
            }

            _taskDataService.Setup(service => service.GetAll()).Returns(expectedItems);

            var actualItems = CreateController().Get();

            Assert.AreEqual(expectedItems.Count, actualItems.Count);
            for (var i = 0; i < tasksCount; i++)
            {
                Assert.AreSame(expectedItems[i], actualItems[i]);
            }
        }

        

        [TestMethod]
        public void AddMethodShouldSaveTask()
        {
            var dataToSend = new Task
            {
                Name = "Name"
            };

            var dataToBeReceived = new Task
            {
                Id = Guid.NewGuid(),
                Name = "Name"
            };

            _taskDataService.Setup(service => service.Add(dataToSend)).Returns(dataToBeReceived);

            var createdTask = CreateController().Post(dataToSend);
            Assert.AreSame(dataToBeReceived, createdTask);
        }

        private TaskController CreateController()
        {
            return new TaskController(_taskDataService.Object);
        }
    }
}
