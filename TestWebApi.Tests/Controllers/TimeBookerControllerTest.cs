using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using DataAccessLib;
using DataAccessLib.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TestWebApi;
using TestWebApi.Controllers;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestWebApi.Tests.Controllers
{
    [TestFixture]
    public class TimeBookerControllerTest
    {
        private IRepository<TimeBooker> _dbRepository;

        [SetUp]
        public void Init()
        {
            _dbRepository = new MockRepository();
        }


        [Test]
        public void When_Get_Expect_Success()
        {
            // Arrange
            var controller = new TimeBookerController(_dbRepository);

            // Act
            var results = controller.Get();

            // Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(4, results.Count());
        }

        [Test]
        public void When_GetById_Expect_Equal()
        {
            // Arrange
            var controller = new TimeBookerController(_dbRepository);
            var expectedBooking = new TimeBooker
            {
                Id = 4,
                IsRemoved = false,
                Created = new DateTime(2017, 12, 15, 16, 22, 33),
                Project = "Project Four",
                Time = "5.3"
            };


            // Act
            var result = controller.Get(4);
            var contentResult = result as OkNegotiatedContentResult<TimeBooker>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(expectedBooking.Id, contentResult.Content.Id);
            Assert.AreEqual(expectedBooking.IsRemoved, contentResult.Content.IsRemoved);
            Assert.AreEqual(expectedBooking.Created, contentResult.Content.Created);
            Assert.AreEqual(expectedBooking.Project, contentResult.Content.Project);
            Assert.AreEqual(expectedBooking.Time, contentResult.Content.Time);
        }

        [Test]
        public void When_GetById_Expect_NotFound()
        {
            // Arrange
            var controller = new TimeBookerController(_dbRepository);


            // Act
            var result = controller.Get(8);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }



        [Test]
        public void When_Post_Expect_Success()
        {
            // Arrange
            var controller = new TimeBookerController(_dbRepository);

            var newBooking = new TimeBooker
            {
                Id = 5,
                IsRemoved = false,
                Created = new DateTime(),
                Project = "Project Five",
                Time = "8"
            };

            // Act
            var result = controller.Post(newBooking);
            var contentResult = result as OkNegotiatedContentResult<int>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(contentResult);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<int>));
            Assert.AreEqual(5, contentResult.Content);

        }


       

        [Test]
        public void When_Put_Expect_Success()
        {
            // Arrange
            var controller = new TimeBookerController(_dbRepository);

            var updatedBooking = new TimeBooker
            {
                Id = 3,
                IsRemoved = false,
                Created = new DateTime(2017, 12, 14, 15, 22, 33),
                Project = "Project Three",
                Time = "18"
            };

            // Act
            var result = controller.Put(3, updatedBooking) as OkResult;
            var checkResult = controller.Get(3);
            var checkContentResult= checkResult as OkNegotiatedContentResult<TimeBooker>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(checkContentResult);
            Assert.IsInstanceOfType(result, typeof(OkResult));
            Assert.AreEqual(updatedBooking.Time, checkContentResult.Content.Time);
           
        }

        [Test]
        public void When_Delete_Expect_Success()
        {
            // Arrange
            var controller = new TimeBookerController(_dbRepository);

            // Act
            var result = controller.Delete(3);
            var contentResult = result as OkNegotiatedContentResult<int>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(contentResult);
            Assert.IsInstanceOfType(contentResult, typeof(OkNegotiatedContentResult<int>));
            Assert.AreEqual(3, contentResult.Content);
        }

        [Test]
        public void When_Delete_Expect_NotFound()
        {
            // Arrange
            var controller = new TimeBookerController(_dbRepository);


            // Act
            var result = controller.Delete(8);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
