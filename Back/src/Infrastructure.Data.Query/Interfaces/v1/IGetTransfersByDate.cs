using Infrastructure.Data.Query.Queries.v1.Transfers.GetTransfersByDate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Query.Interfaces.v1
{
    public interface IGetTransfersByDate
    {
        Task<IEnumerable<GetTransferByDateResponse>> GetTransfersByDate(DateTime DateInicial, DateTime DateFinal);
    }
}
