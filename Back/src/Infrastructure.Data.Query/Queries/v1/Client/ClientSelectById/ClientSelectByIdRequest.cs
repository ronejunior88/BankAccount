using MediatR;

namespace Infrastructure.Data.Query.Queries.v1.Client.ClientSelectById
{
    public class ClientSelectByIdRequest: IRequest<ClientSelectByIdResponse>
    {
        public ClientSelectByIdRequest(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
