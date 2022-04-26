using System.Collections;
using System.Collections.Generic;
namespace BasicAccountOperations.Domain.Model
{
    public class Client
    {
        public int ClientId { get; set; }

        public int idPerson { get; set; }

        public IEnumerable<BankAccount> idAccount { get; set; }     
    }
}