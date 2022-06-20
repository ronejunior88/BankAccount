using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Command.Context.Command.v1.TransferBank.UpdateTransferBankAccount
{
    public class UpdateTransferBankAccountRequest : IRequest<UpdateTransferBankAccountResponse>
    {
        public UpdateTransferBankAccountRequest()
        {  }
    }
}
