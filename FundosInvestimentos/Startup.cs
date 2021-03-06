using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FundosInvestimentos.Data;
using FundosInvestimentos.Data.Repository;
using FundosInvestimentos.Interfaces;
using FundosInvestimentos.Interfaces.InstituicaoInterface;
using FundosInvestimentos.Interfaces.TipoInstituicaoInterface;
using FundosInvestimentos.Models;
using FundosInvestimentos.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace FundosInvestimentos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyContext>(
                context => context.UseNpgsql(Configuration.GetConnectionString("Default"))
            );

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<InstituicaoServiceInterface, InstituicaoService>();
            services.AddScoped<TipoInstituicaoInterface, TipoInstituicaoService>();

            services.AddControllers().AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FundosInvestimentos", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FundosInvestimentos v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
