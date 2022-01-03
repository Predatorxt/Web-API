using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebAPI.Data
{
    public class AppDbInitializer
    {
        public static void seed(IApplicationBuilder applicationBuilder)
        {
            using (var servicescope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = servicescope.ServiceProvider.GetService<AppDbContext>();
                if (!context.books.Any())
                {
                    context.books.AddRange(new Models.Book()
                    {

                        Title = "Hello",
                        Description = "Description",
                        IsRead = true,
                        DateRead=DateTime.Now.AddDays(-10),
                        Rate=4,
                        Genre="Biography",
                        Author="I",
                        CoverUrl="Https......",
                        Dated=DateTime.Now
                    },
                    new Models.Book()
                    {

                        Title = "Hello World",
                        Description = "World",
                        IsRead = false,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "History",
                        Author = "Me",
                        CoverUrl = "Https......",
                        Dated = DateTime.Now
                    }
                    );
                    context.SaveChanges();
                    


                }
            }
        }
    }
}
