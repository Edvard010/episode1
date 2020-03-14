using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace episode1.Models
{
    public class LinqPlay
    {
        public void Test()
        {

            var items = GetItems();
            //var tools = items.Where(x => x.Category == "Tools");
            //var tools = items.Where(x => x.Category == "Tools");
            //var axe = tools.First(x => x.Name == "Axe");
            //var totalPriceOfTools = items.Sum(x => x.Price);
            //var food = items.Where(x => x.Category == "Food");
            //var foodAndTools = tools.Union(food);

            //foreach (var item in foodAndTools)
            //{
            //    Console.WriteLine(item.Name);
            //}
            //var query = items.Where(x => x.CreatedAt >= DateTime.UtcNow.AddDays(-10))
            //    .Where(x => x.Price > 300)
            //    .Skip(1)
            //    .Take(2)
            //    .OrderBy(x => x.Price)
            //    .Select(x => new { x.Name, x.Price });
            var query = items.Where(x => x.DriveTrain == "Shimano");
            var groupedItems = items.GroupBy(x => x.DriveTrain);
            var Dictionary = query.ToDictionary(x => x.Brand, x => x.Model);
            foreach (var item in query)
            {
                Console.WriteLine(item.Brand);
                Console.WriteLine(item.Model);
                Console.WriteLine();
            }
        }
        public IEnumerable<Bike> GetItems()
        {
            yield return new Bike("Specialized", "Tarmac", "Shimano", 15000, DateTime.UtcNow.AddDays(-15));
            yield return new Bike("Bianchi", "Oltre", "Campagnolo", 25000, DateTime.UtcNow.AddDays(-15));
            yield return new Bike("Pinarello", "Dogma", "Shimano", 28000, DateTime.UtcNow.AddDays(-15));
            yield return new Bike("Giant", "TCR", "Shimano", 15000, DateTime.UtcNow.AddDays(-15));
            yield return new Bike("Ridley", "Noah", "SRAM", 18000, DateTime.UtcNow.AddDays(-15));
            yield return new Bike("Wilier", "CentoAir", "Campagnolo", 21000, DateTime.UtcNow.AddDays(-15));
            yield return new Bike("Cannondale", "SuperSix", "Shimano", 19500, DateTime.UtcNow.AddDays(-15));
            yield return new Bike("Focus", "Paralane", "SRAM", 9000, DateTime.UtcNow.AddDays(-15));

        }
    }
    public class Bike //LINQ 
    {
        public Guid Id { get; protected set; }
        public string Brand { get; protected set; }
        public string Model { get; protected set; }
        public string DriveTrain { get; protected set; }
        public decimal Price { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public Bike(string brand, string model, string drivetrain, decimal price, DateTime createdAt)
        {
            Id = Guid.NewGuid();
            Brand = brand;
            Model = model;
            DriveTrain = drivetrain;
            Price = price;
            CreatedAt = createdAt;
        }
    }
}
