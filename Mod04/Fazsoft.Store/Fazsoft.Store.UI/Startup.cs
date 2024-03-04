using Fazsoft.Store.Data.EF;
using Fazsoft.Store.Data.EF.Repositories;
using Fazsoft.Store.Domain.Contracts.Repositories;
using Fazsoft.Store.IoCDI;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using System.IO;

namespace Fazsoft.Store.UI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.SetupServices();
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme =
                options.DefaultSignInScheme =
                options.DefaultAuthenticateScheme =
                CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = "/Auth/Login";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath = "/node_modules",
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules"))

            });
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //Alterar cultura da Aplicação
            var cultureInfo = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


            app.UseEndpoints(endpoints =>
            {
                //AddEdit/x -> Editar
                endpoints.MapControllerRoute("Edit", "{controller}/Editar/{id}", new { action = "AddEdit" });

                //AddEdit -> Adicionar
                endpoints.MapControllerRoute("Add", "{controller}/Adicionar", new { action = "AddEdit" });

                //{controller|home}/{action|index}/{id?}
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}