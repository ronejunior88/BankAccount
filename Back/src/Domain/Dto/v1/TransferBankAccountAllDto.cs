﻿using System;
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
            Transfer = idTransfer;
            Client_Id = idClient;
            Person_Id = idPerson;
            Account = idAccount;
            TypeAccount = typeAccount;
            Name = nameBank;
            TypeTransfer = typeTransfer;
            ValueTransfer = valueTranfer;
        }
        public int Transfer { get; set; }
        public int Client_Id { get; set; }
        public int Person_Id { get; set; }
        public int Account { get; set; }
        public string TypeAccount { get; set; }
        public string Name { get; set; }
        public string TypeTransfer { get; set; }
        public decimal ValueTransfer { get; set; }
    }
}
