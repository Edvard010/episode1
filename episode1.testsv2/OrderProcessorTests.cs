using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using episode1.Models;
using Moq;
using FluentAssertions;

namespace episode1.testsv2
{
    [TestFixture]
    public class OrderProcessorTests
    {
        public User User;
        public Order Order;
        public Mock<IDataBase> DatabaseMock;
        public Mock<IEmailSender> EmailSenderMock;
        public IOrderProcessor OrderProcessor;
        [SetUp]
        public void Setup()
        {
            User = new User("user1@gmail.com", "secret");
            Order = new Order(1, 10);
            DatabaseMock = new Mock<IDataBase>();
            EmailSenderMock = new Mock<IEmailSender>();
            DatabaseMock.Setup(x => x.GetUser(User.Email))
                .Returns(User);
            DatabaseMock.Setup(x => x.GetOrder(Order.Id))
                .Returns(Order);
            OrderProcessor = new OrderProcessor(DatabaseMock.Object, EmailSenderMock.Object);
        }
        [Test]
        public void Process_order_should_suceed()
        {
            //Arrange
            User.IncreaseFunds(100);
            User.Activate();
            //Act
            OrderProcessor.ProcessOrder(User.Email, Order.Id);
            //Assert
            DatabaseMock.Verify(x => x.GetUser(User.Email), Times.Once);
            DatabaseMock.Verify(x => x.GetOrder(Order.Id), Times.Once);
            Assert.IsTrue(Order.IsPurchased);
            //Order.IsPurchased.Should().BeTrue(); //fluent assertions
        }
    }
}
