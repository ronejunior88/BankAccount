using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto.v1
{
    public class TransferBankAccountAllDto
    {
        public TransferBankAccountAllDto()
        { }

        public TransferBankAccountAllDto(int idTransfer, int idClient, int idPerson, int idAccount, string typeAccount, string nameBank, string typeTransfer, decimal valueTranfer)
        {
            IdTransfer = idTransfer;
            IdAccount = idClient;
            IdPerson = idPerson;
            IdAccount = idAccount;
            TypeAccount = typeAccount;
            NameBank = nameBank;
            TypeTransfer = typeTransfer;
            ValueTransfer = valueTranfer;
        }
        public int IdTransfer { get; set; }
        public int IdClient { get; set; }
        public int IdPerson { get; set; }
        public int IdAccount { get; set; }
        public string TypeAccount { get; set; }
        public string NameBank { get; set; }
        public string TypeTransfer { get; set; }
        public decimal ValueTransfer { get; set; }
    }
}
