using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto.v1
{
    public class TransferBankAccountIdDto
    {
        public TransferBankAccountIdDto()
        { }

        public TransferBankAccountIdDto(int idTransfer, int idBankAccount, decimal valueTransfer, string typeTransfer, DateTime date)
        {
            IdTransfer = idTransfer;
            IdBankAccount = idBankAccount;
            ValueTransfer = valueTransfer;
            TypeTransfer = typeTransfer;
            Date = date;
        }
        public int IdTransfer { get; set; }
        public int IdBankAccount { get; set; }
        public decimal ValueTransfer { get; set; }
        public string TypeTransfer { get; set; }
        public DateTime Date { get; set; }
    }
}
