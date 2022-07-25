using System;

namespace Domain.Dto.v1
{
    public class TransferBankAccountIdClientDto
    {
        public TransferBankAccountIdClientDto()
        { }
        public TransferBankAccountIdClientDto(int idTransfer, int idClient, int idPerson, int idAccount, string typeAccount, string nameBank, string typeTransfer, decimal valueTranfer, DateTime date)
        {
            Transfer = idTransfer;
            Client_Id = idClient;
            Person_Id = idPerson;
            Account = idAccount;
            TypeAccount = typeAccount;
            Name = nameBank;
            TypeTransfer = typeTransfer;
            ValueTransfer = valueTranfer;
            Date = date; ;
        }
        public int Transfer { get; set; }
        public int Client_Id { get; set; }
        public int Person_Id { get; set; }
        public int Account { get; set; }
        public string TypeAccount { get; set; }
        public string Name { get; set; }
        public string TypeTransfer { get; set; }
        public decimal ValueTransfer { get; set; }
        public DateTime Date { get; set; }
    }
}
