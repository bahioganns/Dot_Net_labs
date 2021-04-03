using Domain;
using Domain.Models;
using BLL.Contracts;
using BLL.Implementations;
using DataAccess.Contracts;
using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;

namespace BLL.Test
{
    public class UserServiceTests
    {
        private Mock<IUserDataAccess> fakeUserDataAccess;
        private User expected;

        [SetUp]
        public void SetUp()
        {
            fakeUserDataAccess = new Mock<IUserDataAccess>();
            expected = new User{ Id=1, Email="123@456.ru", Description="1234567" };
        }

        [Test]
        public void TestCreateUser()
        {
            // Arrange
            fakeUserDataAccess.Setup(x => x.Insert(It.IsAny<UserUpdateModel>())).Returns(expected);

            // Action
            var userService = new UserService(fakeUserDataAccess.Object);
            User user = userService.CreateUser(new UserUpdateModel());

            // Assert
            Assert.AreEqual(user.Id, expected.Id);
            Assert.AreEqual(user.Email, expected.Email);
            Assert.AreEqual(user.Description, expected.Description);
        }

        [Test]
        public void TestGetUser()
        {
            // Arrange
            fakeUserDataAccess.Setup(x => x.Get(It.IsAny<UserIdentityModel>())).Returns(expected);

            // Action
            var userService = new UserService(fakeUserDataAccess.Object);
            User user = userService.GetUser(new UserIdentityModel(1));

            // Assert
            Assert.AreEqual(user.Id, expected.Id);
            Assert.AreEqual(user.Email, expected.Email);
            Assert.AreEqual(user.Description, expected.Description);
        }

        [Test]
        public void TestUpdateUser()
        {
            // Arrange
            fakeUserDataAccess.Setup(x => x.Update(It.IsAny<UserIdentityModel>(), It.IsAny<UserUpdateModel>())).Returns(expected);

            // Action
            var userService = new UserService(fakeUserDataAccess.Object);
            User user = userService.UpdateUser(new UserIdentityModel(1), new UserUpdateModel());

            // Assert
            Assert.AreEqual(user.Id, expected.Id);
            Assert.AreEqual(user.Email, expected.Email);
            Assert.AreEqual(user.Description, expected.Description);
        }

        [Test]
        public void TestDeleteUser()
        {
            // Arrange
            fakeUserDataAccess.Setup(x => x.Delete(It.IsAny<UserIdentityModel>()));

            // Action
            var userService = new UserService(fakeUserDataAccess.Object);
            userService.DeleteUser(new UserIdentityModel(1));

            // Assert
            fakeUserDataAccess.Verify(x => x.Delete(It.IsAny<UserIdentityModel>()), Times.Once());
        }

        [Test]
        public void TestSuccessfullValidateUser()
        {
            // Arrange
            List<UserUpdateModel> goodUserUpdateModels = new List<UserUpdateModel>();
            goodUserUpdateModels.Add(new UserUpdateModel{ Email="qweqwe@ya.ru", Description="123" });
            goodUserUpdateModels.Add(new UserUpdateModel{ Email="123@yandex.com", Description="123" });
            goodUserUpdateModels.Add(new UserUpdateModel{ Email="qwe@mail.ru", Description="123" });
            goodUserUpdateModels.Add(new UserUpdateModel{ Email="alex@google.com", Description="123" });

            // Action
            var userService = new UserService(fakeUserDataAccess.Object);

            // Assert
            goodUserUpdateModels.ForEach((user) => {
                Assert.DoesNotThrow(() => userService.ValidateUser(user));
            });
        }

        [Test]
        public void TestFaildeValidateUser()
        {
            // Arrange
            List<UserUpdateModel> badUserUpdateModels = new List<UserUpdateModel>();
            badUserUpdateModels.Add(new UserUpdateModel{ Email="qweqweya.ru", Description="123" });
            badUserUpdateModels.Add(new UserUpdateModel{ Email="@ya.ru", Description="123" });
            badUserUpdateModels.Add(new UserUpdateModel{ Email="qy@1.u", Description="123" });
            badUserUpdateModels.Add(new UserUpdateModel{ Email="qy1.u", Description="123" });

            // Action
            var userService = new UserService(fakeUserDataAccess.Object);

            // Assert
            badUserUpdateModels.ForEach((user) => {
                Assert.Catch<ArgumentException>(() => userService.ValidateUser(user));
            });
        }
    }
}
