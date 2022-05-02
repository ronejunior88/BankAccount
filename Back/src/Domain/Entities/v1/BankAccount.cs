namespace Domain.Entities.v1
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int IdBank { get; set; }
        public int IdClient { get; set; }
        public double Balance { get; set; }
        public string TypeAccount { get; set; }
    }         
    
}