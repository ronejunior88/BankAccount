using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto.v1
{
    public class TransferBankAccountAllDto
    {
        public TransferBankAccountAllDto()
        { }

        public TransferBankAccountAllDto(int idClient, int idPerson, int idAccount, decimal balance, string typeAccount, string nameBank, string typeTransfer, string valueTranfer)
        {
            IdAccount = idClient;
            IdPerson = idPerson;
            IdAccount = idAccount;
            Balance = balance;
            TypeAccount = typeAccount;
            NameBank = nameBank;
            TypeTransfer = typeTransfer;
            ValueTransfer = valueTranfer;
        }
        public int IdClient { get; set; }
        public int IdPerson { get; set; }
        public int IdAccount { get; set; }
        public decimal Balance { get; set; }
        public string TypeAccount { get; set; }
        public string NameBank { get; set; }
        public string TypeTransfer { get; set; }
        public string ValueTransfer { get; set; }
    }
}
