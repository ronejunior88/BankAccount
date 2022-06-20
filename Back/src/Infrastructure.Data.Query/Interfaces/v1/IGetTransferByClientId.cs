using Infrastructure.Data.Query.Queries.v1.Transfers.GetTransferByClientId;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data.Query.Interfaces.v1
{
    public interface IGetTransferByClientId
    {
        Task<IEnumerable<GetTransferByClientIdResponse>> GetTransferByClientIdAsync(int idClient);
    }
}
