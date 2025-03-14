using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Models;

namespace ECommerce.Data
{
    public static class SampleData
    {
        public static void Initialize(AppDbContext db)
        {

            if (db.Categories.Any())
            {
                return;   
            }


            var electronics = new Category { Name = "Electronics", Description = "Electronic devices and gadgets" };
            var clothing = new Category { Name = "Clothing", Description = "Apparel and fashion items" };
            var books = new Category { Name = "Books", Description = "Books and publications" };

            db.Categories.Add(electronics);
            db.Categories.Add(clothing);
            db.Categories.Add(books);
            db.SaveChanges();


            var smartphone = new Product
            {
                Name = "Smartphone",
                Price = 7000M,
                Description = "Latest smartphone model",
                Img = "/imgs/smartphone.jpg",
                CategoryId = electronics.Id
            };

            var laptop = new Product
            {
                Name = "Laptop",
                Price = 30000M,
                Description = "Powerful laptop for work and gaming",
                Img = "/imgs/laptop.jpg",
                CategoryId = electronics.Id
            };

            var tshirt = new Product
            {
                Name = "T-Shirt",
                Price = 500M,
                Description = "Comfortable cotton t-shirt",
                Img = "/imgs/T-shirt.jpg",
                CategoryId = clothing.Id
            };

            var jeans = new Product
            {
                Name = "Jeans",
                Price = 700M,
                Description = "Classic blue jeans",
                Img = "/imgs/jeans.jpg",
                CategoryId = clothing.Id
            };

            var book = new Product
            {
                Name = "Programming Book",
                Price = 150M,
                Description = "Learn programming with this book",
                Img = "/imgs/book.jpg",
                CategoryId = books.Id
            };

            db.Products.Add(smartphone);
            db.Products.Add(laptop);
            db.Products.Add(tshirt);
            db.Products.Add(jeans);
            db.Products.Add(book);
            db.SaveChanges();


            var islam = new Customer
            {
                Name = "Islam Ali",
                Email = "islamali@gmail.com",
                Phone = "01012232322"
            };

            var mohamed = new Customer
            {
                Name = "Mohamed Ali",
                Email = "moali@gmail.com",
                Phone = "01167232322"
            };

            db.Customers.Add(islam);
            db.Customers.Add(mohamed);
            db.SaveChanges();


            var order1 = new Order
            {
                CustomerId = islam.Id,
                OrderDate = DateTime.Now.AddDays(-5),
                TotalAmount = 8000M
            };

            var order2 = new Order
            {
                CustomerId = mohamed.Id,
                OrderDate = DateTime.Now.AddDays(-2),
                TotalAmount = 650M
            };

            db.Orders.Add(order1);
            db.Orders.Add(order2);
            db.SaveChanges();

            var orderItem1 = new OrderItem
            {
                OrderId = order1.Id,
                ProductId = smartphone.Id,
                Quantity = 1,
                Price = smartphone.Price
            };

            var orderItem2 = new OrderItem
            {
                OrderId = order1.Id,
                ProductId = tshirt.Id,
                Quantity = 2,
                Price = tshirt.Price
            };

            var orderItem3 = new OrderItem
            {
                OrderId = order2.Id,
                ProductId = tshirt.Id,
                Quantity = 1,
                Price = tshirt.Price
            };

            var orderItem4 = new OrderItem
            {
                OrderId = order2.Id,
                ProductId = book.Id,
                Quantity = 1,
                Price = book.Price
            };

            db.OrderItems.Add(orderItem1);
            db.OrderItems.Add(orderItem2);
            db.OrderItems.Add(orderItem3);
            db.OrderItems.Add(orderItem4);
            db.SaveChanges();
        }
    }
}