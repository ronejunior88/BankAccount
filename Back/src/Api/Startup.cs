using Infrastructure.Data.Command.Context.Command.v1.Bank;
using Infrastructure.Data.Command.Context.Command.v1.Client;
using Infrastructure.Data.Command.Context.Command.v1.Transfer;
using Infrastructure.Data.Command.Context.Interfaces.v1.Bank;
using Infrastructure.Data.Command.Context.Interfaces.v1.Transfer;
using Infrastructure.Data.Command.Interfaces.v1.Client;
using Infrastructure.Data.Context.Infrastructure.Ioc;
using Infrastructure.Data.Context.Interfaces.v1;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Data.SqlClient;

namespace Api
{
    public class Startup
    {
        public IConfiguration _cofiguration { get; }

        public Startup(IConfiguration configuration)
        {
            _cofiguration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            Func<IServiceProvider, SqlConnection> Connect =
                 a => new SqlConnection(_cofiguration.GetConnectionString("BankAccount"));

            services.AddScoped(Connect);
            services.AddScoped<IClientCommandInterface, ClientCommand>();
            services.AddScoped<IBankAccountCommanderInterface, BankAccountCommand>();
            services.AddScoped<ITransferBankAccountInterface, TransferBankAccountCommand>();
            services.AddScoped<IBootstrapper, Bootstrapper>();
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Api Bank Account", Version = "v1" });
            });
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProEventos.API v1"));
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowAllHeaders");
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
