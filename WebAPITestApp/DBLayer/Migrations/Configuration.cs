namespace DBLayer.Migrations
{
    //using System.Collections.Generic;
    //using DbData;
    //using System;
    //using System.Data.Entity.Migrations;

    //internal sealed class Configuration : DbMigrationsConfiguration<DBLayer.Contexts.OrderContext>
    //{
    //    public Configuration()
    //    {
    //        AutomaticMigrationsEnabled = false;
    //    }

    //    protected override void Seed(Contexts.OrderContext context)
    //    {
    //        var user = new User
    //        {
    //            FirstName = "TestUser",
    //            SecondName = "SecondName"
    //        };

    //        context.Users.AddOrUpdate(user);

    //        var products = new List<Product>
    //        {
    //            new Product
    //            {
    //                ProductName = "ProdName1",
    //                Description = "Product1",
    //                Costs = 15.9
    //            },
    //            new Product
    //            {
    //            ProductName = "ProdName2",
    //            Description = "Product2",
    //            Costs = 15.9
    //        }
    //        };

    //        products.ForEach(item => context.Products.AddOrUpdate(item));

    //        context.Orders.AddOrUpdate(new Order
    //        {
    //            OrderedDate = DateTime.Now,
    //            Products = products,
    //            Users = user,
    //            UserId = user.Id
    //        });

    //    }
    //}
}
