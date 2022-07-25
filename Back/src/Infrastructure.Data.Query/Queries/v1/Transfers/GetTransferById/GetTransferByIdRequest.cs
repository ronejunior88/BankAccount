using MediatR;

namespace Infrastructure.Data.Query.Queries.v1.Transfers.GetTransferById
{
    public class GetTransferByIdRequest : IRequest<GetTransferByIdResponse>
    {
        public GetTransferByIdRequest(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
