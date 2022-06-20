using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Query.Queries.v1.Transfers.GetTransferByClientId
{
    public class GetTransferByClientIdRequest: IRequest<IEnumerable<GetTransferByClientIdResponse>>
    {
        public GetTransferByClientIdRequest(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
