using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MegaDeskWeb.Model
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MegaDeskDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<MegaDeskDBContext>>()))
            {
                // Look for any movies.
                if (!context.Rush.Any())
                    context.Rush.AddRange(
                        new Rush
                        {
                            days = 0,
                            priceLarge = 0,
                            priceMedium = 0,
                            priceSmall = 0,
                        },
                        new Rush
                        {
                            days = 3,
                            priceLarge = 60,
                            priceMedium = 70,
                            priceSmall = 80,
                        },
                        new Rush
                        {
                            days = 5,
                            priceLarge = 40,
                            priceMedium = 50,
                            priceSmall = 60,
                        },
                        new Rush
                        {
                            days = 7,
                            priceLarge = 30,
                            priceMedium = 35,
                            priceSmall = 40,
                        }
                    );
                if (!context.Material.Any())
                    context.Material.AddRange(
                        new Material
                        {
                            cost = 200,
                            type = "Oak",
                        },
                        new Material
                        {
                            cost = 100,
                            type = "Laminate",
                        },
                        new Material
                        {
                            cost = 50,
                            type = "Pine",
                        },
                        new Material
                        {
                            cost = 300,
                            type = "Rosewood",
                        },
                        new Material
                        {
                            cost = 125,
                            type = "Veneer",
                        }
                    );
                context.SaveChanges();
            }
        }

    }
}
