using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using episode1.Models;

namespace episode1.testsv2
{
    [TestFixture]
    public class UserTests
    {
        public User User;
        [SetUp]
        public void Setup()
        {
            User = new User("user1@gmail.com", "secret");
        }
        [Test]
        public void Changing_email_should_succeed()
        {
            //Arrange
            var expectedEmail = "user2@email.com";

            //Act
            User.SetEmail(expectedEmail);
            //Assert
            Assert.AreEqual(User.Email, expectedEmail);
        }
        [Test]
        public void Providing_empty_password_should_fail()
        {
            //Arrange

            //Act
            var exception = Assert.Throws<Exception>(() => User.SetPassword(string.Empty));
            //Assert
            Assert.IsNotNull(exception);
            Assert.IsTrue(exception.Message.Equals("Password is incorrect."));
        }
    }
}

