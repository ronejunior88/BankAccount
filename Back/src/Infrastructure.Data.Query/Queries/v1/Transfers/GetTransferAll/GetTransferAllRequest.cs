using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Query.Queries.v1.Transfers.GetTransferAll
{
    public class GetTransferAllRequest : IRequest<IEnumerable<GetTransferAllResponse>>
    {
        public GetTransferAllRequest()
        { }
    }
}
