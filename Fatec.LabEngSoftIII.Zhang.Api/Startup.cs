﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Fatec.LabEngSoftIII.Zhang.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(o => o.AddPolicy("CorsPolicy", b => b
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
            )) ;

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Zhang - Jogo da Forca",
                        Version = "v1",
                        Description = "API Desenvolvida para o Jogo da Forca Zhang.<br>Trabalho para a matéria de Engenharia de Software III do curso de ADS (noite) da FATEC-SP<br><br>Integrantes:<br>Allan Prado de Oliveira Moura<br>Augusto Albuquerque Reis<br>Bruna Ramos<br>Danillo Felipe Aragão<br>Danilo Tupinambá Polizeli<br>Gabriel Alves da Silva<br>Gustavo Rocha da Silva<br>Shayanne Crispim de Medeiros Amorim<br>Tatiana Rodrigues de Oliveira",
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Jogo da Forca Zhang");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors("CorsPolicy");
            app.UseMvc();
        }
    }
}
