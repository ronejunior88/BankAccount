using Domain.Entities.v1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

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
