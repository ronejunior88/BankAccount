using MediatR;
using System.Collections.Generic;

namespace Infrastructure.Data.Query.Queries.v1.Transfers.GetTransferAll
{
    public class GetTransferAllRequest : IRequest<IEnumerable<GetTransferAllResponse>>
    {
        public GetTransferAllRequest()
        { }
    }
}
