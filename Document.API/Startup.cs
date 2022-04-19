using Application.Applications;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Services;
using FluentValidation.AspNetCore;
using Infrastruture.Configurations;
using Infrastruture.Repository;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Document.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Document.API", Version = "v1" });
            });
            services.AddDbContext<FinancialContext>(cfg =>
            {
                cfg.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging();
            });
            services.AddScoped<CashBookRepository>();
            services.AddScoped<DocumentRepository>();
            services.AddScoped<OrderRepository>();
            services.AddScoped<OrderProductRepository>();

            services.AddScoped<ICashBook, CashBookService>();
            services.AddScoped<IDocument, DocumentService>();
            services.AddScoped<IOrder, OrderService>();
            services.AddScoped<IOrderProduct, OrderProductService>();


            services.AddScoped<ICashBookApplication, CashBookApplication>();
            services.AddScoped<IDocumentApplication, DocumentApplication>();
            services.AddScoped<IOrderApplication, OrderApplication>();
            services.AddScoped<IOrderProductApplication, OrderProductApplication>();
            services.AddControllers()
                .AddFluentValidation(s =>
                {
                    s.RegisterValidatorsFromAssemblyContaining<Startup>();
                    s.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Document.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
