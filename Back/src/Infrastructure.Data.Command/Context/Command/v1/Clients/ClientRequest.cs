using Domain.Entities.v1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Command.Context.Command.v1.Clients
{
    public class ClientRequest: IRequest<ClientResponse>
    {
        public ClientRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
