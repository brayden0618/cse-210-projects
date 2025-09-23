using System;

namespace OnlineOrdering
{
    public class Product
    {
        private int _productId;
        private string _name;
        private string _description;
        private decimal _price;
        private int _stockQuantity;

        public Product(int productId, string name, string description, decimal price, int stockQuantity)
        {
            _productId = productId;
            _name = name;
            _description = description;
            _price = price;
            _stockQuantity = stockQuantity;
        }

        public decimal Price => _price;
        public string Name => _name;

        public void UpdateStock(int quantity)
        {
            _stockQuantity += quantity;
        }
        
        public override string ToString()
        {
            return $"Product ID: {_productId}, Name: {_name}, Description: {_description}, Price: {_price:C}, Stock Quantity: {_stockQuantity}";
        }
    }
}