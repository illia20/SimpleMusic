﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleMusic.Data;

[assembly: HostingStartup(typeof(SimpleMusic.Areas.Identity.IdentityHostingStartup))]
namespace SimpleMusic.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SimpleMusicContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SimpleMusicContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<SimpleMusicContext>();
            });
        }
    }
}