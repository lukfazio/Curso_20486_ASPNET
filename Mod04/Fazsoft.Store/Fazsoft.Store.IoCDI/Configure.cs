using Fazsoft.Store.Data.EF;
using Fazsoft.Store.Data.EF.Repositories;
using Fazsoft.Store.Domain.Contracts.Data;
using Fazsoft.Store.Domain.Contracts.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazsoft.Store.IoCDI
{
    public static class Configure
    {
        public static  void SetupServices(this IServiceCollection services)
        {            
            services.AddScoped<StoreDbContext>();

            services.AddTransient<IUnitOfWork, UnitOfWorkEF>();
            services.AddTransient<IProdutoRepository, ProdutoRepositoryEF>();
            services.AddTransient<ICategoriaRepository, CategoriaRepositoryEF>();
            services.AddTransient<IUsuarioRepository, UsuarioRepositoryEF>();
            services.AddTransient<IPerfilRepository, PerfilReposirotyEF>();
        }
    }
}
