using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcRefactor.Entity;
using MvcRefactor.Logging;
using MvcRefactor.Service;
using MvcRefactorTest.Controllers;

namespace MvcRefactorTest.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private Mock<IUserService> moqService;
        private IUserService userService;
        private ILogger logService;
        private User user;
        [TestInitialize]
        public void SetUp()
        {
            user = new User
            {
                UserName = "Alax Pham",
                Role = "Tester",
                Enabled = true
            };

            List<User> users = new List<User>
            {
                new User{UserId = 1, UserName = "Pham Minh Duc", Role = "Description",Enabled = true},
                new User{UserId = 2, UserName = "Pham Duc Minh", Role = "PM",Enabled = true},
                new User{UserId = 3, UserName = "Pham Minh Tri", Role = "QA",Enabled = true},
            };

            moqService = new Mock<IUserService>();

            moqService.Setup(mUserS => mUserS.GetAll()).Returns(users);
            moqService.Setup(mUserS => mUserS.Insert(user)).Returns(true);
            logService = new FileLogManager(typeof(HomeController));

            userService = moqService.Object;
        }

        [TestMethod]
        public void Index()
        {
            //Return All Users 
            var users = userService.GetAll();
            //Assert.IsNotNull(user);
            Assert.AreEqual(3, users.Count());
        }

        [TestMethod]
        public void InsertNewContent()
        {
            var chkInsert = userService.Insert(user);
            Assert.AreEqual(true, chkInsert);
        }
        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(userService);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController(userService);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
