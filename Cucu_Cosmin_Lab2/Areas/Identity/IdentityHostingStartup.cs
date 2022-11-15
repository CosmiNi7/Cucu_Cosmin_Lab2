using System;
using Cucu_Cosmin_Lab2.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Cucu_Cosmin_Lab2.Areas.Identity.IdentityHostingStartup))]
namespace Cucu_Cosmin_Lab2.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LibraryIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LibraryIdentityContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<LibraryIdentityContext>();
            });
        }
    }
}