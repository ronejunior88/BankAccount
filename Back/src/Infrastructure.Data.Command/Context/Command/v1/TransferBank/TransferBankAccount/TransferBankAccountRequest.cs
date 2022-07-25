using Domain.Entities.v1;
using MediatR;

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
