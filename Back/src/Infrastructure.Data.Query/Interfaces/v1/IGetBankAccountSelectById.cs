using Infrastructure.Data.Query.Queries.v1.BankAccount.GetBankAccountSelectById;
using System.Threading.Tasks;

namespace Infrastructure.Data.Query.Interfaces.v1
{
    public interface IGetBankAccountSelectById
    {
        Task<GetBankAccountSelectByIdResponse> GetBankAccountSelectByIdAsync(int Id);
    }
}
