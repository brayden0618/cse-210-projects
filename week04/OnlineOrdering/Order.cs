using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineOrdering
{
    public class Order
    {
        private int _orderId;
        private List<Product> _products;
        private Customer _customer;

        public Order(int orderId, Customer customer)
        {
            _orderId = orderId;
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var product in _products)
            {
                total += product.Price;
            }
            return total;
        }

        public string GetPackingLabel()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Packing Label:");
            sb.AppendLine($"Order ID: {_orderId}");
            sb.AppendLine($"Customer: {_customer.Name}");
            sb.AppendLine("Products:");
            foreach (var product in _products)
            {
                sb.AppendLine($" - {product.Name}");
            }
            return sb.ToString();
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\nCustomer: {_customer.Name}\nAddress: {_customer.ShippingAddress}";
        }

        public override string ToString()
        {
            return $"Order ID: {_orderId}, Customer: {_customer.Name}, Products Count: {_products.Count}, Total: {CalculateTotal():C}";
        }
    }
}