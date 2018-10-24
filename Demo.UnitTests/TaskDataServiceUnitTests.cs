using System;
using System.Collections.Generic;
using System.Linq;
using Demo.DataService.SqlServer;
using Demo.Models;
using Demo.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.UnitTests
{
    [TestClass]
    public class TaskDataServiceUnitTests
    {
        private const string DatabaseName = "Demo";

        private ApplicationDbContext _dbContext;
        private TaskDataService _taskDataService;

        [TestInitialize]
        public void TestInitialize()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase(DatabaseName);
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);
            _taskDataService = new TaskDataService(_dbContext);
        }

        [TestMethod]
        public void GetAllMethodShouldFetchAllRecords()
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
                _dbContext.Tasks.Add(task);
            }

            _dbContext.SaveChanges();

            var result = _taskDataService.GetAll();

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

        [TestMethod]
        public void AddMethodShouldSaveTheRecord()
        {
            var expectedName = RandomTaskFieldValue.Name();
            var expectedDescription = RandomTaskFieldValue.Description();
            var expectedCreatedAt = new DateTime();

            var task = new Task
            {
                Name = expectedName,
                Description = expectedDescription,
            };

            var result = _taskDataService.Add(task);
            Assert.AreSame(task, result);
            Assert.AreSame(result, _dbContext.Tasks.Single(x => x.Id == task.Id));
            Assert.IsFalse(_dbContext.ChangeTracker.HasChanges());

            Assert.AreNotEqual(Guid.Empty, task.Id);
            Assert.AreEqual(expectedName, task.Name);
            Assert.AreEqual(expectedDescription, task.Description);
            Assert.AreEqual(expectedCreatedAt, task.CreatedAt);
            Assert.IsFalse(task.Completed);
            Assert.IsFalse(task.DueDate.HasValue);
            Assert.IsFalse(task.CompletedAt.HasValue);
        }

        [TestMethod]
        public void EditMethodShouldChangeExistingRecord()
        {
            var previousRecord = new Task
            {
                Name = RandomTaskFieldValue.Name(),
                Description = RandomTaskFieldValue.Description(),
                Completed = false,
                CreatedAt = DateTime.Now
            };
            _dbContext.Tasks.Add(previousRecord);
            _dbContext.SaveChanges();

            var recordId = previousRecord.Id;
            Assert.AreNotEqual(Guid.Empty, recordId);

            var expectedName = RandomTaskFieldValue.Name();
            var expectedDescription = RandomTaskFieldValue.Description();
            const bool expectedCompleted = true;
            var expectedCompletedAt = DateTime.Now;

            var currentRecord = new Task
            {
                Id = recordId,
                Name = expectedName,
                Description = expectedDescription,
                Completed = expectedCompleted,
                CompletedAt = expectedCompletedAt
            };

            var result = _taskDataService.Edit(currentRecord);
            Assert.AreSame(result, previousRecord);
            Assert.AreSame(result, _dbContext.Tasks.Single(task => task.Id == recordId));
            Assert.IsFalse(_dbContext.ChangeTracker.HasChanges());

            Assert.AreEqual(expectedName, result.Name);
            Assert.AreEqual(expectedDescription, result.Description);
            Assert.AreEqual(expectedCompleted, result.Completed);
            Assert.AreEqual(expectedCompletedAt, result.CompletedAt);
        }
    }
}
