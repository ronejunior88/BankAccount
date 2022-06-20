using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Query.Queries.v1.BankAccount.GetBankAccountSelectById
{
    public class GetBankAccountSelectByIdResponse
    {
        public int Id { get; set; }
        public int IdBank { get; set; }
        public int IdClient { get; set; }
        public decimal Balance { get; set; }
        public string TypeAccount { get; set; }
    }
}
