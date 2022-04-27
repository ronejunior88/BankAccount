namespace BasicAccountOperations.Domain.Model
{
    public class Transfer
    {
        public int Id { get; set; }
        public string typeTransFer { get; set; }
        public double ValueTransfer { get; set; }
        public BankAccount IdbankAccount { get; set; }                
    }
}