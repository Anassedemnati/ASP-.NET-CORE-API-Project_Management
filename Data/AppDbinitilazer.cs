using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api_pract.Data.Models;

namespace web_api_pract.Data
{
    public class AppDbinitilazer
    {

        public static void Seed(IApplicationBuilder applicationBulder)
        {
            using (var  serviseScope= applicationBulder.ApplicationServices.CreateScope()) 
            {
                var context = serviseScope.ServiceProvider.GetService<ApplicationDbContext>();
                if (!context.Projects.Any())
                {
                    context.Projects.AddRange(new Project {
                    Name="Project web",
                    createDate=DateTime.Now.AddDays(-10),
                    finished= false,
                    custumer="Jumia"
                    },
                    new Project
                    {
                        Name = "Project backend",
                        createDate = DateTime.Now.AddDays(-20),
                        finished = false,
                        custumer = "Avito"

                    }
                    );
                    context.SaveChanges();
                }
            }
        }

    }
}
