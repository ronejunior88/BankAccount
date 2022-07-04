using MediatR;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Query.Queries.v1.Transfers.GetTransfersByDate
{
    public class GetTransferByDateRequest : IRequest<IEnumerable<GetTransferByDateResponse>>
    {
        public GetTransferByDateRequest()
        {  }

        public GetTransferByDateRequest(DateTime dateInicial, DateTime dateFinal)
        {
            DateInicial = dateInicial;
            DateFinal = dateFinal;
        }
        public DateTime DateInicial { get; set; }
        public DateTime DateFinal { get; set; }
    }
}
