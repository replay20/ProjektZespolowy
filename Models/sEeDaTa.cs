using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcPracownik.Models;
using System;
using System.Linq;
using WebApplication1.Models.Data;

namespace WebApplication1.Models
{
    public class sEeDaTa
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PracownicyContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PracownicyContext>>()))
            {
                // Look for any pracownik.
                /*if (context.Pracownik.Any())
                {
                    return context.Pracownik;   // DB has been seeded
                }*/

                context.Pracownik.AddRange(
                    new Pracownik
                    {
                        login = "yeee",
                        haslo = "neee"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
