using MediatR;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Query.Queries.v1.Transfers.GetTransfersByDateAndClientId
{
    public class GetTransfersByDateAndClientIdRequest : IRequest<IEnumerable<GetTransfersByDateAndClientIdResponse>>
    {
        public GetTransfersByDateAndClientIdRequest()
        { }
        public GetTransfersByDateAndClientIdRequest(DateTime dateInicial, DateTime dateFinal, int idClient)
        {
            DateInicial = dateInicial;
            DateFinal = dateFinal;
            IdClient = idClient;
        }
        public DateTime DateInicial { get; set; }
        public DateTime DateFinal { get; set; }
        public int IdClient { get; set; }
    }
}
