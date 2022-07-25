using MediatR;
using System.Collections.Generic;

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
