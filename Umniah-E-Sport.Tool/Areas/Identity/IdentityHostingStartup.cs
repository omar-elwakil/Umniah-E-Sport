using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Umniah_E_Sport.Tool.Data;

[assembly: HostingStartup(typeof(Umniah_E_Sport.Tool.Areas.Identity.IdentityHostingStartup))]
namespace Umniah_E_Sport.Tool.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Umniah_E_SportToolContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Umniah_E_SportToolContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Umniah_E_SportToolContext>();
            });
        }
    }
}