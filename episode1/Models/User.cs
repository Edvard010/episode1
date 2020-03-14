﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace episode1.Models
{
    public class User
    {
        private ISet<Order> _orders = new HashSet<Order>();
        
        public string Email { get; private set; } //property
        [UserPassword(length: 6)]
        public string Password { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime UpdateAt { get; private set; }
        public decimal Funds { get; private set; }
        public IEnumerable<Order> Orders { get { return _orders; } }
        public User(string email, string password)
        //konstruktor do Usera
        //musi mieć przy tworzeniu nadany email i hasło
        {
            SetEmail(email);
            SetPassword(password);
        }
        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email is incorrect.");
            }
            if (Email == email)
            {
                return;
            }
            Email = email;
            Update();
        }
        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password is incorrect.");
            }
            if (Password == password)
            {
                return;
            }
            Password = password;
            Update();
        }
        public void SetAge(int age)
        {
            if (age < 13)
            {
                throw new Exception("Age must be greater or equal 13.");
            }
            if (Age == age)
            {
                return;
            }
            Age = age;
            Update();
        }
        public void Activate()
        {
            if (IsActive)
            {
                return;
            }
            IsActive = true;
            Update();
        }
        public void DeActivate()
        {
            if (!IsActive)
            {
                return;
            }
            IsActive = false;
            Update();
        }
        public void IncreaseFunds(decimal funds)
        {
            if (funds <= 0)
            {
                throw new Exception("Funds must be greater than 0.");
            }
            Funds += funds;
            Update();
        }
        public void PurchaseOrder(Order order)
        {
            if (!IsActive)
            {
                throw new Exception("Only active users can purchase an order");
            }
            decimal orderPrice = order.TotalPrice;
            if (Funds - orderPrice < 0)
            {
                throw new Exception("U don't have enough money.");
            }
            order.Purchase();
            Funds -= orderPrice;
            _orders.Add(order);
            Update();
        }
        private void Update()
        {
            UpdateAt = DateTime.UtcNow;
        }
    }
}
