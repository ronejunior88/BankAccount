using Infrastructure.Data.Query.Queries.v1.Transfers.GetTransferById;
using System.Threading.Tasks;

namespace Infrastructure.Data.Query.Interfaces.v1
{
    public interface IGetTransferById
    {
        Task<GetTransferByIdResponse> GetTransferByIdAsync(int idTransfer);
    }
}
