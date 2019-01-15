using System;
using IdsWithAspIds.Areas.Identity.Data;
using IdsWithAspIds.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(IdsWithAspIds.Areas.Identity.IdentityHostingStartup))]
namespace IdsWithAspIds.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdsWithAspIdsContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdsWithAspIdsContextConnection")));

                //services.AddDefaultIdentity<IdsWithAspIdsUser>()
                    //.AddEntityFrameworkStores<IdsWithAspIdsContext>();
            });
        }
    }
}