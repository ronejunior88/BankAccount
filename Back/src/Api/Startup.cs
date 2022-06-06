using AutoMapper;
using Domain.Dto.v1;
using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Command.v1.Bank;
using Infrastructure.Data.Command.Context.Command.v1.Client;
using Infrastructure.Data.Command.Context.Command.v1.TransferBank;
using Infrastructure.Data.Command.Context.Interfaces.v1.Bank;
using Infrastructure.Data.Command.Context.Interfaces.v1.TransferBank;
using Infrastructure.Data.Command.Interfaces.v1.Client;
using Infrastructure.Data.Repository.Infrastructure.v1;
using Infrastructure.Data.Repository.Interfaces.v1;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {

            var connectionString = _configuration.GetConnectionString("BankAccount");

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Transfer, TransferDto>();
            });
            IMapper mapper = config.CreateMapper();

            

            services.AddSingleton(mapper);

            
            services.AddScoped<IClient, ClientCommand>();
            services.AddScoped<IBankAccount, BankAccountCommand>();
            services.AddScoped<ITransferBankAccount, TransferBankAccountCommand>();
            services.AddScoped<IBankAccountRepository, BankAccountRepository>();
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
