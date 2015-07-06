using System.Collections.Generic;
using Xunit;
using Moq;
using MvcRefactor.Data;
using MvcRefactor.Entity;
using MvcRefactor.Service.Implementation;

namespace MvcRefactorTest.Test.xUnit
{
    public class TestBussiness
    {
        private UserService userService;
        private Mock<IDALContext> moqIDALContext;
        private IDALContext _IDALContext;
        private User user;

        public TestBussiness()
        {
            user = new User
            {
                UserName = "Alax Pham",
                Role = "Tester",
                Enabled = true
            };

            var users = new List<User>
            {
                new User{UserId = 1, UserName = "Pham Minh Duc", Role = "Description",Enabled = true},
                new User{UserId = 2, UserName = "Pham Duc Minh", Role = "PM",Enabled = true},
                new User{UserId = 3, UserName = "Pham Minh Tri", Role = "QA",Enabled = true},
            };

            // Setup 
            moqIDALContext = new Mock<IDALContext>();
            //moqIDALContext.Setup(db => db.Users).Verifiable();
            // Assert
            _IDALContext = moqIDALContext.Object;
            userService = new UserService(_IDALContext);
        }

        /// <summary>
        /// If Role of user is Admin, status "enabled" must is true
        /// </summary>
        [Fact]
        public void TestInsertUserSuccessfull()
        {
            var userAdmin = new User
            {
                UserName = "Mr Been",
                Role = "Admin",
                Enabled = true
            };
            //Action
            var chkInsert = userService.Insert(userAdmin);
            // Assert
            moqIDALContext.Verify(m => m.Users.Create(userAdmin), Times.Exactly(1));
            moqIDALContext.Verify(m => m.SaveChanges(), Times.Exactly(1));

            // Statebased testing
            Assert.Equal(true, chkInsert);

        }
        /// <summary>
        /// Write to log if User admin is not correct
        /// </summary>
        [Fact]
        public void FaillingTestInsertUser()
        {
            var userAdmin = new User
            {
                UserName = "Mr Been",
                Role = "Admin",
                Enabled = false
            };
            //Action          

            var chkInsert = userService.Insert(userAdmin);
            // Assert
            moqIDALContext.Verify(m => m.Users.Create(userAdmin), Times.Never());
            moqIDALContext.Verify(m => m.SaveChanges(), Times.Never());
            Assert.Equal(false, chkInsert);
        }
    }
}
