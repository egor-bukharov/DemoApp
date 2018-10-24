using System;
using System.Collections.Generic;
using Demo.Controllers;
using Demo.DataService;
using Demo.Models;
using Demo.UnitTests.Common;
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
            var tasksCount = RandomValue.Integer(10, 100);

            var expectedItems = new List<Task>(tasksCount);

            for (var i = 0; i < tasksCount; i++)
            {
                var item = new Task { Name = RandomTaskFieldValue.Name() };
                expectedItems.Add(item);
            }

            _taskDataService.Setup(service => service.GetAll()).Returns(expectedItems);

            var actualItems = CreateControllerInstance().Get();

            Assert.AreEqual(expectedItems.Count, actualItems.Count);
            for (var i = 0; i < tasksCount; i++)
            {
                Assert.AreSame(expectedItems[i], actualItems[i]);
            }
        }


        [TestMethod]
        public void PostMethodShouldDelegateToTaskDataService()
        {
            var dataToSend = new Task
            {
                Name = RandomTaskFieldValue.Name()
            };

            var expectedId = Guid.NewGuid();
            var expectedName = RandomTaskFieldValue.Name();

            var dataToBeReceived = new Task
            {
                Id = expectedId,
                Name = expectedName
            };

            _taskDataService.Setup(service => service.Add(dataToSend)).Returns(dataToBeReceived);

            var createdTask = CreateControllerInstance().Post(dataToSend);
            Assert.AreSame(dataToBeReceived, createdTask);

            Assert.AreEqual(expectedId, createdTask.Id);
            Assert.AreEqual(expectedName, createdTask.Name);
        }

        [TestMethod]
        public void PutMethodShouldDelegateToTaskDataService()
        {
            var dataToSend = new Task();

            CreateControllerInstance().Put(dataToSend);

            _taskDataService.Verify(service => service.Edit(dataToSend));
        }

        private TaskController CreateControllerInstance()
        {
            return new TaskController(_taskDataService.Object);
        }
    }
}
