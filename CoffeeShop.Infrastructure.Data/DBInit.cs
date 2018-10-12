using CoffeeShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Infrastructure.Data
{
    public class DBInit
    {
        public static void SeedDB(CoffeeShopAppContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            Client Stalin = new Client
            {
                Name = "Stalin",
                PassWord = "marxwasokiguess",
                BillingAddress = "Stalingrad",
                BirthDate = new DateTime(1922, 04, 3)

            };

            Client Lenin = new Client
            {
                Name = "Lenin",
                PassWord = "marxisthebest",
                BillingAddress = "Leningrade",
                BirthDate = new DateTime(1922, 12, 30)

            };

            Client Castro = new Client
            {
                Name = "Fidel Castro",
                PassWord = "marxsucked",
                BillingAddress = "A cave in Cuba",
                BirthDate = new DateTime(1961, 06, 24)

            };

            ctx.Clients.Add(Stalin);
            ctx.Clients.Add(Lenin);
            ctx.Clients.Add(Castro);

            Coffee C1 = new Coffee
            {
                Name = "LeninCoffee",
                Category = "Ground",
                Prise = 36251,
                Country = "Costa Rica"
            };

            Coffee C2 = new Coffee
            {
                Name = "Black death",
                Category = "Beans",
                Prise = 593782,
                Country = "Columbia"
            };

            Coffee C3 = new Coffee
            {
                Name = "Tha BOMB",
                Category = "Ground",
                Prise = 635721,
                Country = "New Zealand"
            };

            ctx.Coffees.Add(C1);
            ctx.Coffees.Add(C2);
            ctx.Coffees.Add(C3);

            Order O1 = new Order
            {
                Client = Lenin,
                Date = new DateTime (2018, 01, 22),
                OrderedItem = C1
            };

            Order O2 = new Order
            {
                Client = Castro,
                Date = new DateTime(2018, 04, 20) ,
                OrderedItem = C3
            };

            Order O3 = new Order
            {
                Client = Castro,
                Date = new DateTime(2018, 04, 20),
                OrderedItem = C2
            };

            Order O4 = new Order
            {
                Client = Stalin,
                Date = new DateTime(2018, 01, 23),
                OrderedItem = C1
            };

            ctx.Orders.Add(O1);
            ctx.Orders.Add(O2);
            ctx.Orders.Add(O3);
            ctx.Orders.Add(O4);
            ctx.SaveChanges();
        }
    }
}
