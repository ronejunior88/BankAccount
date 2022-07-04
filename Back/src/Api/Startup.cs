using AutoMapper;
using Domain.Dto.v1;
using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Command.v1.Bank.InsertBankAccount;
using Infrastructure.Data.Command.Context.Command.v1.Persons;
using Infrastructure.Data.Command.Context.Command.v1.Persons.Insert_Person;
using Infrastructure.Data.Command.Context.Command.v1.TransferBank;
using Infrastructure.Data.Command.Context.Command.v1.TransferBank.TransferBankAccount;
using Infrastructure.Data.Command.Context.Command.v1.TransferBank.UpdateTransferBankAccount;
using Infrastructure.Data.Command.Context.Interfaces.v1.TransferBank;
using Infrastructure.Data.Query.Queries.v1.BankAccount.GetBankAccountSelectById;
using Infrastructure.Data.Query.Queries.v1.Client.ClientSelectById;
using Infrastructure.Data.Query.Queries.v1.Transfers.GetTransferAll;
using Infrastructure.Data.Query.Queries.v1.Transfers.GetTransferByClientId;
using Infrastructure.Data.Query.Queries.v1.Transfers.GetTransferById;
using Infrastructure.Data.Query.Queries.v1.Transfers.GetTransfersByDate;
using Infrastructure.Data.Repository.Infrastructure.v1;
using Infrastructure.Data.Repository.Interfaces.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

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
                cfg.CreateMap<Transfer, TransferDto>().ReverseMap();
                cfg.CreateMap<Person, Insert_PersonResponse>().ReverseMap();
                cfg.CreateMap<ClientPersonDto, ClientSelectByIdResponse>().ReverseMap();
                cfg.CreateMap<BankAccountDto, GetBankAccountSelectByIdResponse>().ReverseMap();
                cfg.CreateMap<BankAccount, InsertBankAccountRequest>().ReverseMap();
                cfg.CreateMap<BankAccount, InsertBankAccountResponse>().ReverseMap();
                cfg.CreateMap<Transfer, GetTransferByIdResponse>().ReverseMap();
                cfg.CreateMap<TransferBankAccountIdClientDto, GetTransferByClientIdResponse>().ReverseMap();
                cfg.CreateMap<GetTransferAllResponse, TransferBankAccountAllDto>().ReverseMap();
                cfg.CreateMap<Transfer, TransferBankAccountRequest>().ReverseMap();
                cfg.CreateMap<Transfer, TransferBankAccountResponse>().ReverseMap();
                cfg.CreateMap<Transfer, UpdateTransferBankAccountResponse>().ReverseMap();
                cfg.CreateMap<Transfer, UpdateTransferBankAccountRequest>().ReverseMap();
                cfg.CreateMap<TransferBankAccountAllDto, GetTransferByDateResponse>().ReverseMap();
            });
            IMapper mapper = config.CreateMapper();

            

            services.AddSingleton(mapper);    
            services.AddScoped<IBankAccountRepository, BankAccountRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ITransferRepository, TransferRepository>();
            services.AddControllers();

            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(IConfiguration));
            services.AddMediatR(typeof(Insert_PersonHandler).Assembly);
            services.AddMediatR(typeof(ClientSelectByIdHandler).Assembly);
            services.AddMediatR(typeof(GetBankAccountSelectByIdHandler).Assembly);
            services.AddMediatR(typeof(InsertBankAccountHandler).Assembly);
            services.AddMediatR(typeof(GetTransferByIdHandler).Assembly);
            services.AddMediatR(typeof(GetTransferByClientIdHandler).Assembly);
            services.AddMediatR(typeof(GetTransferAllHandler).Assembly);
            services.AddMediatR(typeof(UpdateTransferBankAccountHandler).Assembly);
            services.AddMediatR(typeof(TransferBankAccountHandler).Assembly);
            services.AddMediatR(typeof(GetTransferByDateHandler).Assembly);

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
