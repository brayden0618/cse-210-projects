using System;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

            //Create Address
            var address1 = new Address("123 Main St", "Springfield", "IL", "62701");
            var address2 = new Address("456 Elm St", "Metropolis", "IL", "62960");

            //Create Customers
            var customer1 = new Customer(1, "John Doe", "John@example.com", address1);
            var customer2 = new Customer(2, "Jane Smith", "Jane@example.com", address2);

            //Create Products
            var product1 = new Product(101, "Laptop", "High performance laptop", 999.99m, 10);
            var product2 = new Product(102, "Smartphone", "Latest model smartphone", 699.99m, 20);
            var product3 = new Product(103, "Headphones", "Noise-cancelling headphones", 199.99m, 15);
            var product4 = new Product(104, "Monitor", "4K UHD Monitor", 399.99m, 5);
            var product5 = new Product(105, "Keyboard", "Mechanical keyboard", 89.99m, 25);

            //Create Orders
            var order1 = new Order(1, customer1);
            order1.AddProduct(product1);
            order1.AddProduct(product3);
            customer1.AddOrder(order1);

            var order2 = new Order(2, customer2);
            order2.AddProduct(product2);
            order2.AddProduct(product4);
            order2.AddProduct(product5);
            customer2.AddOrder(order2);

            //Display Order Details
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Order 1 Total: {order1.CalculateTotal():C}");
            Console.WriteLine($"Order 2 Total: {order2.CalculateTotal():C}");
        }
    }
}