using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Command.v1.TransferBank.TransferBankAccount;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Interfaces.v1.TransferBank
{
    public interface ITransferBankAccount
    {
        Task<TransferBankAccountResponse> InsertTransferBankAccountAsync(Transfer transfer);
    }
}
