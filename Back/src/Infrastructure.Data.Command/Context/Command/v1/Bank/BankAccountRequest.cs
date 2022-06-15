using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Command.Context.Command.v1.Bank
{
    public class BankAccountRequest : IRequest<BankAccountReponse>
    {
    }
}
