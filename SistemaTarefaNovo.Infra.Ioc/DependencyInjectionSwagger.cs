using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTarefaNovo.Infra.Ioc
{    public static class DependencyInjectionSwagger
     {
        //public static IServiceCollection AddInfraestruturaSwagger(this IServiceCollection services)
        //{


        //    services.AddSwaggerGen(c =>
        //    {

        //            // Define o esquema de segurança JWT
        //            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        //            {
        //                Description = "JWT Authorization header using the Bearer scheme",
        //                Type = SecuritySchemeType.Http,
        //                Scheme = "bearer"
        //            });

        //                      // Define os requisitos de segurança para as operações que exigem autenticação JWT
        //         c.AddSecurityRequirement(new OpenApiSecurityRequirement
        //            {
        //                {
        //                    new OpenApiSecurityScheme
        //                    {
        //                        Reference = new OpenApiReference
        //                        {
        //                            Type = ReferenceType.SecurityScheme,
        //                            Id = "Bearer"
        //                        }
        //                    },
        //                    new string[] {}
        //                }
        //            });


        //            });

        //            return services;
        //}


               }
}
