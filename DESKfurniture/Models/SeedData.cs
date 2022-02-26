using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DESKfurniture.Data;
using System;
using System.Linq;

namespace DESKfurniture.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DESKfurnitureContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DESKfurnitureContext>>()))
            {
                // Look for any movies.
                if (context.Desk.Any())
                {
                    return;   // DB has been seeded
                }

                context.Desk.AddRange(
                    new Desk
                    {
                        Shop = "The Brick",
                        Usage = "House Furniture",
                        Material = "Wooden",
                        Price = 67.59M
                    },
                    new Desk
                    {
                        Shop = "The Home Depot",
                        Usage = "House Furniture",
                        Material = "Glass",
                        Price = 94.56M
                    },
                    new Desk
                    {
                        Shop = "Eagle Office Furnishings Inc",
                        Usage = "Office Work",
                        Material = "Metal",
                        Price = 62.9M
                    },
                    new Desk
                    {
                        Shop = "Ashley HomeStore",
                        Usage = "House Furniture",
                        Material = "Glass/Clear",
                        Price = 34.46M
                    },
                    new Desk
                    {
                        Shop = "Monarch Basics",
                        Usage = "School/Children",
                        Material = "Metal",
                        Price = 55.69M
                    },
                    new Desk
                    {
                        Shop = "Structube",
                        Usage = "Office Work",
                        Material = "Glass",
                        Price = 75.94M
                    },
                    new Desk
                    {
                        Shop = "Staples",
                        Usage = "All",
                        Material = "Glass/Wooden",
                        Price = 88.68M
                    },
                    new Desk
                    {
                        Shop = "Office Depot",
                        Usage = "Office work",
                        Material = "Wooden/Metal",
                        Price = 47.99M
                    },
                    new Desk
                    {
                        Shop = "Best Buy",
                        Usage = "All",
                        Material = "Metal/Glass",
                        Price = 62.91M
                    },
                    new Desk
                    {
                        Shop = "OfficeMax",
                        Usage = "Office/School",
                        Material = "Wooden/Metal",
                        Price = 52.96M
                    }



                );
                context.SaveChanges();
            }
        }
    }
}
