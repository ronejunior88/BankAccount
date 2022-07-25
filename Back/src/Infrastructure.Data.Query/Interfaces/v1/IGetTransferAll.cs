using Infrastructure.Data.Query.Queries.v1.Transfers.GetTransferAll;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data.Query.Interfaces.v1
{
    public interface IGetTransferAll
    {
        Task<IEnumerable<GetTransferAllResponse>> GetTransferAllAsync();
    }
}
