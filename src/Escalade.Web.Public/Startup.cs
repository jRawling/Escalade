using Escalade.Application.UserSession;
using Escalade.Domain.Persistence;
using Escalade.Persistence.Mock;
using Escalade.Web.Public.Identity;
using Escalade.Web.Public.Models;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.Framework.Logging.Console;
using System;

namespace Escalade.Web.Public
{
    public class Startup
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services
                .AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                .AddUserStore<UserStore>()
                .AddRoleStore<RoleStore>();
            //services.AddTransient<IUserRepository, UserRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddTransient<IUserSession, UserSession>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            if (IsDevelopmentEnvironment())
            {
                ConfigureForDevelopment(app, loggerFactory);
            }

            app.UseStaticFiles();
            app.UseIdentity();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }

        public void ConfigureForDevelopment(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            //app.UseBrowserLink();
            app.UseErrorPage(ErrorPageOptions.ShowAll);
        }

        private bool IsDevelopmentEnvironment()
        {
            return string.Equals(hostingEnvironment.EnvironmentName, "Development", StringComparison.OrdinalIgnoreCase);
        }
    }
}