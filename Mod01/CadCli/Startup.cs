using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadCli.Core.Contracts;
using CadCli.Core.Data.ADO;
using CadCli.Core.Data.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CadCli
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //Sobe o CadCliDbContext uma única vez na Aplicação (Singleton)
            //services.AddSingleton<CadCliDbContext>();

            //Sobe o CadCliDbContext na requisiçao do Usuario
            services.AddScoped<CadCliDbContext>();

            //Sobe o CadCliDbContext a cada requisicao            
            services.AddTransient<IRepository, RepositoryEF>();
            //services.AddTransient<IRepository, RepositoryADO>();

        }

        private int IRepository()
        {
            throw new NotImplementedException();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration config)
        {
            var manutencao = Convert.ToBoolean(config["EstaEmManutencao"]);
            if (manutencao)
            {
                //CircuitBreak: Interrompe sem passar para os proximos Middlewares
                app.Run(async (ctx) =>
                {
                    await ctx.Response.WriteAsync("App em Manutencao!");
                });
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.Use(async (ctx, next) =>
            {
                Console.WriteLine("Passou na Ida!");

                if (!ctx.Request.Path.ToString().Contains("xpto"))
                {
                    //Passa na Ida
                    await next.Invoke();
                    //Passa na volta
                    Console.WriteLine("Passou na volta!");
                }
                else
                {
                    await ctx.Response.WriteAsync("XPTO nao existe!");
                }               

            });

            app.UseEndpoints(endpoints =>
            {
                //[Controller=Home]/[method-action=Index]/{id?}
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
