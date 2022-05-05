namespace Domain.Entities.v1
{
    public class Transfer
    {
        public Transfer()
        {  }

        public Transfer(string typeTransfer, decimal valueTransfer, int idBankAccount)
        {
            IdBankAccount = idBankAccount;
            ValueTransfer = valueTransfer;
            TypeTransFer = typeTransfer;    
        }

        public Transfer(int id, int idBankAccount, decimal valueTransfer, string typeTransfer)
        {
            Id = id;
            IdBankAccount = idBankAccount;
            ValueTransfer = valueTransfer;
            TypeTransFer = typeTransfer;
        }
        public int Id { get; set; }
        public int IdBankAccount { get; set; }
        public decimal ValueTransfer { get; set; }
        public string TypeTransFer { get; set; }
        
                       
    }
}