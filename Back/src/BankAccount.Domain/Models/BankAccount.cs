using BasicAccountOperations.Domain.Enums;

namespace BasicAccountOperations.Domain.Model
{
    public class BankAccount
    {
        public int Id { get; set; }

        public int IdBanco { get; set; }

        public int IdClient { get; set; }
        public double Balance { get; set; }

        public typeAccount Type { get; set; }
    }         
    
}