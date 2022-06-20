using Domain.Entities.v1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Command.Context.Command.v1.TransferBank.TransferBankAccount
{
    public class TransferBankAccountRequest : IRequest<TransferBankAccountResponse>
    {
        public TransferBankAccountRequest(Transfer transfer)
        {
            Transfer = transfer;
        }
        public Transfer Transfer { get; set; }
    }
}
