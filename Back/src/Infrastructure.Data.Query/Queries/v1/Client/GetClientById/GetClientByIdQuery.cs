using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Query.Queries.v1.Client.GetClientById
{
    public class GetClientByIdQuery : IRequest<GetClientByIdProcedureResponse>
    {
        public GetClientByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
