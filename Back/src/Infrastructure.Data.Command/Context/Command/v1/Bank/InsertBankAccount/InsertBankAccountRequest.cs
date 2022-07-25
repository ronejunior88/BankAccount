using Domain.Entities.v1;
using MediatR;

namespace Infrastructure.Data.Command.Context.Command.v1.Bank.InsertBankAccount
{
    public class InsertBankAccountRequest : BankAccount, IRequest<InsertBankAccountResponse>
    {    }
}
