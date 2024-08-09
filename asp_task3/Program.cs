using asp_task3.Data;
using Microsoft.EntityFrameworkCore;

namespace asp_task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            //CRUD
            //Create
            //for product
            List<Product> products = new List<Product>
            {
                new Product() { Name = "cola", Price = 10 },
                new Product() { Name = "labtop", Price = 2000 },
                new Product() { Name = "computer", Price = 1500 }
            };

            context.Products.AddRange(products);

            //for Order
            List<Order> orders = new List<Order>
            {
                new Order(){Address="Attil"},
                new Order(){Address="Tulkarm"},
                new Order(){Address="Ramallah"},

            };
            context.Orders.AddRange(orders);
            context.SaveChanges();

            //Read
            //for product
            var allProducts = context.Products.ToList();
            Console.WriteLine("All Products:");
            allProducts.ForEach(p => Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Price: {p.Price}"));

            //for Order
            var allOrders = context.Orders.ToList();
            Console.WriteLine("\nAll Orders:");
            allOrders.ForEach(o => Console.WriteLine($"Id: {o.Id}, Address: {o.Address}, CreadetAt: {o.CreadetAt}")
            );

            //Update
            //for product
            var product = context.Products.FirstOrDefault(p => p.Id == 1);
            if (product is not null)
            {
                product.Name = "new Name";
                context.SaveChanges();
             
            }

            //for Order
           
            var order = context.Orders.FirstOrDefault(o => o.Id == 1);
            if (order is not null)
            {
                order.CreadetAt = DateTime.Now;
                context.SaveChanges();
           
            }

            //Delete
            //for product
           
            var removeProduct = context.Products.FirstOrDefault(p => p.Id == 2);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
               
            }
            //for Order
             var removeOrder = context.Orders.FirstOrDefault(o => o.Id == 3);
            if (order != null)
            {
                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }
    }
}
