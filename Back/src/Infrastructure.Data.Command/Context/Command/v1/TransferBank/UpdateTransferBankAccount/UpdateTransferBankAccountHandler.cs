using AutoMapper;
using Domain.Dto.v1;
using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Interfaces.v1.TransferBank;
using Infrastructure.Data.Command.Context.Rabbit.v1;
using Infrastructure.Data.Repository.Infrastructure.v1;
using Infrastructure.Data.Repository.Interfaces.v1;
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
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private ITransferRepository _transferRepository;
        private IBankAccountRepository _bankAccountRepository;
        public UpdateTransferBankAccountHandler(IConfiguration configuration, IMapper mapper, ITransferRepository transferBankAccount, IBankAccountRepository bankAccountRepository)
        {
            _configuration = configuration;
            _mapper = mapper;
            _transferRepository = transferBankAccount;
            _bankAccountRepository = bankAccountRepository;
        }
        public async Task<UpdateTransferBankAccountResponse> Handle(UpdateTransferBankAccountRequest request, CancellationToken cancellationToken)
        {
            var read = new TransferQueues();
            var listTransfer = read.Read(_configuration);
            foreach (var item in listTransfer)
            {
                var transfer = JsonConvert.DeserializeObject<Transfer>(item);
                var bankAccount = await _bankAccountRepository.GetBankAccountSelectByIdAsync(transfer.IdBankAccount);
                if (transfer.ValueTransfer > 0)
                {
                    _ = transfer.TypeTransFer == "Transferencia" || transfer.TypeTransFer == "Saque" ?
                    bankAccount.Balance = transferWithdraw(transfer, bankAccount) : bankAccount.Balance = bankAccount.Balance + transfer.ValueTransfer;
                    try
                    {
                        await _bankAccountRepository.UpdateBankAccountBalanceByTransferAsync(transfer.IdBankAccount, bankAccount.Balance);
                        var result = await _transferRepository.insertTransferAsync(transfer);
                    }
                    catch (Exception ex)
                    {

                        throw new Exception("Erro com com atualização / inserção da transferencia!", ex);
                    }
                }
            }
            return null;
        }
        public decimal transferWithdraw(Transfer transfer, BankAccountDto bankAccount)
        {
            return bankAccount.Balance > 0 && bankAccount.Balance - transfer.ValueTransfer >= 0
                ? bankAccount.Balance - transfer.ValueTransfer
                : 0;
        }    
    }
}
