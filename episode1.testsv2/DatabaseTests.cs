using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using episode1.Models;

namespace episode1.testsv2
{
    [TestFixture]
    public class DatabaseTests
    {
        public User User;
        public IDataBase Database;

        [SetUp]
        public void Setup()
        {
            User = new User("user1@gmail.com", "secret");
            Database = new DataBase();
        }
        [Test]
        public void Invoking_connect_should_set_is_connected_to_true()
        {
            //Arrange

            //Act
            Database.Connect();
            //Assert
            Assert.IsTrue(Database.IsConnected);
        }

    }
}