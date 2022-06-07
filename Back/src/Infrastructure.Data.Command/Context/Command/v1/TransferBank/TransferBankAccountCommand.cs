using AutoMapper;
using Domain.Dto.v1;
using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Command.v1.Bank;
using Infrastructure.Data.Command.Context.Interfaces.v1.TransferBank;
using Infrastructure.Data.Command.Context.Rabbit.v1;
using Infrastructure.Data.Repository.Infrastructure.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Command.v1.TransferBank
{
    public class TransferBankAccountCommand : ITransferBankAccount
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        private TransferRepository _transferRepository;
        private BankAccountRepository _bankAccountRepository;
        public TransferBankAccountCommand(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("BankAccount");
        }

        public TransferBankAccountCommand()
        { }

        public async Task<JsonResult> GetTransferByIdAsync(int idTransfer)
        {
            _transferRepository = new TransferRepository(_connectionString);
            return await _transferRepository.GetTransferByIdAsync(idTransfer);
        }

        public async Task<IEnumerable<TransferBankAccountIdClientDto>> GetTransferByClientIdAsync(int idClient)
        {
            _transferRepository = new TransferRepository(_connectionString);
            return await _transferRepository.GetTransferByClientIdAsync(idClient);
        }

        public async Task<IEnumerable<TransferBankAccountAllDto>> GetTransferAllAsync()
        {
            _transferRepository = new TransferRepository(_connectionString);
            return await _transferRepository.GetTransferAllAsync();
        }

        public async Task InsertTransferBankAccountAsync(Transfer transfer)
        {
            TransferQueues queues = new TransferQueues();
            var message = JsonConvert.SerializeObject(transfer);
            queues.Send(_configuration, message);
        }

        public decimal transferWithdraw(Transfer transfer, BankAccountDto bankAccount)
        {
            if (bankAccount.Balance > 0 && bankAccount.Balance - transfer.ValueTransfer >= 0)
            {
                return bankAccount.Balance - transfer.ValueTransfer;
            }
            return 0;
        }

        public void insertTransfer(Transfer transfer)
        {
            _transferRepository = new TransferRepository();
            _transferRepository.insertTransferAsync(transfer);
        }

        public async Task UpdateTransferBankAccountAsync()
        {
            _bankAccountRepository = new BankAccountRepository(_connectionString);
            _transferRepository = new TransferRepository(_connectionString);

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
                        await _transferRepository.insertTransferAsync(transfer);
                        
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro: ", ex);
                }
            }
        }       
    }
}
