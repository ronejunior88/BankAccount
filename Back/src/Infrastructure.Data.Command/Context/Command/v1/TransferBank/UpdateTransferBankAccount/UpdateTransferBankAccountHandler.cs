using AutoMapper;
using Domain.Dto.v1;
using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Interfaces.v1.TransferBank;
using Infrastructure.Data.Command.Context.Rabbit.v1;
using Infrastructure.Data.Repository.Infrastructure.v1;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Command.v1.TransferBank.UpdateTransferBankAccount
{
    public class UpdateTransferBankAccountHandler : IUpdateTransferBankAccount, IRequestHandler<UpdateTransferBankAccountRequest, UpdateTransferBankAccountResponse>
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private TransferRepository _transferRepository;
        private BankAccountRepository _bankAccountRepository;

        public UpdateTransferBankAccountHandler(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
            _connectionString = configuration.GetConnectionString("BankAccount");
            _transferRepository = new TransferRepository(_connectionString);
            _bankAccountRepository = new BankAccountRepository(_connectionString);
        }

        public async Task<UpdateTransferBankAccountResponse> Handle(UpdateTransferBankAccountRequest request, CancellationToken cancellationToken)
        {
            var response = await UpdateTransferBankAccountAsync();
            return response;
        }

        public decimal transferWithdraw(Transfer transfer, BankAccountDto bankAccount)
        {
            return bankAccount.Balance > 0 && bankAccount.Balance - transfer.ValueTransfer >= 0
                ? bankAccount.Balance - transfer.ValueTransfer
                : 0;
        }       
        public async Task<UpdateTransferBankAccountResponse> UpdateTransferBankAccountAsync()
        {
            var read = new TransferQueues();
            var listTransfer = read.Read(_configuration);

            foreach (var item in listTransfer)
            {
                var transfer = JsonConvert.DeserializeObject<Transfer>(item);
                var bankAccount = await _bankAccountRepository.GetBankAccountSelectByIdAsync(transfer.IdBankAccount);
                try
                {
                    if (transfer.ValueTransfer > 0)
                    {
                        switch (transfer.TypeTransFer)
                        {
                            case "Deposito":
                                bankAccount.Balance = bankAccount.Balance + transfer.ValueTransfer;
                                break;
                            case "Transferencia":
                                bankAccount.Balance = transferWithdraw(transfer, bankAccount);
                                break;
                            case "Saque":
                                bankAccount.Balance = transferWithdraw(transfer, bankAccount);
                                break;
                            default:
                                break;
                        }
                        await _bankAccountRepository.UpdateBankAccountBalanceByTransferAsync(transfer.IdBankAccount, bankAccount.Balance);
                        var result = await _transferRepository.insertTransferAsync(transfer);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro: ", ex);
                }
            }
            return null;
        }      
    }
}
