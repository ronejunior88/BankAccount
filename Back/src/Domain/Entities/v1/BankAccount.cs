namespace BasicAccountOperations.Domain.Model
{
    public class BankAccount
    {
        public int Id { get; set; }
        public Bank IdBank { get; set; }
        public Client IdClient { get; set; }
        public double Balance { get; set; }
        public string TypeAccount { get; set; }
    }         
    
}