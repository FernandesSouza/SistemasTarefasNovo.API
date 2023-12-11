using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SistemaTarefaNovo.Aplication.Interfaces;
using SistemaTarefaNovo.Aplication.Mappings;
using SistemaTarefaNovo.Aplication.Services;
using SistemaTarefaNovo.Domain.Interfaces;
using SistemaTarefaNovo.Infra.Data.Data;
using SistemaTarefaNovo.Infra.Data.Repositories;
using System.Text;


namespace SistemaTarefaNovo.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestrutura(this IServiceCollection services, IConfiguration configuration)
        {
            // Registre o contexto do banco de dados
            services.AddDbContext<BancoContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("MinhaConexaoBancoDados"), b => b.MigrationsAssembly(typeof(BancoContext).Assembly.FullName)));

            services.AddAutoMapper(typeof(MappingDTOs));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<ITarefaService, TarefaService>();



            return services;
        }


    }
}
