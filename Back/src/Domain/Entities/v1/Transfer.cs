using System;

namespace Domain.Entities.v1
{
    public class Transfer
    {
        public Transfer()
        {  }
        public Transfer(string typeTransfer, decimal valueTransfer, int idBankAccount, DateTime date)
        {
            IdBankAccount = idBankAccount;
            ValueTransfer = valueTransfer;
            TypeTransFer = typeTransfer;
            Date = date;
        }
        public Transfer(int id, int idBankAccount, decimal valueTransfer, string typeTransfer, DateTime date)
        {
            Id = id;
            IdBankAccount = idBankAccount;
            ValueTransfer = valueTransfer;
            TypeTransFer = typeTransfer;
            Date = date;
        }
        public int Id { get; set; }
        public int IdBankAccount { get; set; }
        public decimal ValueTransfer { get; set; }
        public string TypeTransFer { get;  set; }
        public DateTime Date { get; set; }
    }
}