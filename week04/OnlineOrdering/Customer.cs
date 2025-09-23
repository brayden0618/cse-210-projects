using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    public class Customer
    {
        private int _customerId;
        private string _name;
        private string _email;
        private Address _shippingAddress;
        private List<Order> _orders;

        public Customer(int customerId, string name, string email, Address shippingAddress)
        {
            _customerId = customerId;
            _name = name;
            _email = email;
            _shippingAddress = shippingAddress;
            _orders = new List<Order>();
        }

        public Address ShippingAddress => _shippingAddress;
        public string Name => _name;

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public override string ToString()
        {
            return $"Customer ID: {_customerId}, Name: {_name}, Email: {_email}, Shipping Address: {_shippingAddress}, Orders Count: {_orders.Count}";
        }
    }
}