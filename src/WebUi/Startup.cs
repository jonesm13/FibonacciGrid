namespace WebUi
{
    using System;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Domain.Events;
    using Hubs;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton<InMemoryGridFactory>();

            services.AddSignalR();

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();

            app.UseSignalR(builder =>
            {
                builder.MapHub<GridHub>("/api/hubs/grid");
            });

            app.Use(ClientSideEvents);
        }

        Task ClientSideEvents(HttpContext context, Func<Task> next)
        {
            IHubContext<GridHub> hubContext = context
                .RequestServices
                .GetRequiredService<IHubContext<GridHub>>();

            DomainEvents
                .Register<SquareChanged>(theEvent =>
                {
                    hubContext
                        .Clients
                        .All
                        .SendCoreAsync(
                            "squareChanged",
                            new object[] {theEvent});
                });

            return Task.CompletedTask;
        }
    }
}
