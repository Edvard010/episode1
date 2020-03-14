using System;
using System.Collections.Generic;
using System.Text;

namespace episode1.Models
{
    public interface IEmailSender
    {
        void SendMesseage(string receiver, string title, string message);
    }
    public class EmailSender : IEmailSender
    {
        public void SendMesseage(string receiver, string title, string message)
        {
            throw new NotImplementedException();
        }
    }
    public interface IDataBase
    {
        bool IsConnected { get; }
        void Connect();
        User GetUser(string email);
        Order GetOrder(int id);
        void SaveChanges();
    }
    public class DataBase : IDataBase
    {
        public bool IsConnected { get; protected set; }

        public void Connect()
        {
            if (IsConnected)
            {
                return;
            }
            IsConnected = true;
        }

        public Order GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
    public interface IOrderProcessor
    {
        void ProcessOrder(string email, int orderId);
    }
    public class OrderProcessor : IOrderProcessor
    {
        private readonly IDataBase _dataBase;
        private readonly IEmailSender _emailSender;
        public OrderProcessor(IDataBase dataBase, IEmailSender emailSender)
        {
            _dataBase = dataBase;
            _emailSender = emailSender;
        }
        public void ProcessOrder(string email, int orderId)
        {
            User user = _dataBase.GetUser(email);//Fletch from database //if (user == null)  //{ error}
            Order order = _dataBase.GetOrder(orderId);//Fletch from db
            user.PurchaseOrder(order);
            _dataBase.SaveChanges();
            _emailSender.SendMesseage(email, "Order purchased", "You've purchased an order");
        }
    }
    public class FakeEmailSender : IEmailSender
    {
        public void SendMesseage(string receiver, string title, string message)
        {
            throw new NotImplementedException();
        }
    }
    public class FakeDataBase : IDataBase
    {
        public bool IsConnected => throw new NotImplementedException();

        public void Connect()
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
    public class Shop
    {
        public void CompleteOrder()
        {
            IDataBase dataBase = new DataBase();
            IEmailSender emailSender = new EmailSender();
            IOrderProcessor orderProcessor = new OrderProcessor(dataBase, emailSender);
        }
        public void CompleteFakeOrder()
        {
            IDataBase dataBase = new FakeDataBase();
            IEmailSender emailSender = new FakeEmailSender();
            IOrderProcessor orderProcessor = new OrderProcessor(dataBase, emailSender);
        }
    }
}

