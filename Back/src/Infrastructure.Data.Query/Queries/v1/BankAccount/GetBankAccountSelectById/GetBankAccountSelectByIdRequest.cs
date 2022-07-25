using MediatR;

namespace Infrastructure.Data.Query.Queries.v1.BankAccount.GetBankAccountSelectById
{
    public class GetBankAccountSelectByIdRequest : IRequest<GetBankAccountSelectByIdResponse>
    {
        public GetBankAccountSelectByIdRequest(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
