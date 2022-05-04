using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto.v1
{
    public class TransferDto
    {
        public TransferDto(){ }

        public TransferDto(int idbankAccount, decimal valueTransfer, string typeTransFer)
        {
            IdbankAccount = idbankAccount;
            ValueTransfer = valueTransfer;
            TypeTransFer = typeTransFer;
        }
        public int IdbankAccount { get; set; }
        public decimal ValueTransfer { get; set; }
        public string TypeTransFer { get; set; }
    }
}
