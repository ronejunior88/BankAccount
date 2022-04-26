using BasicAccountOperations.Domain.Enums;

namespace BasicAccountOperations.Domain.Model
{
    public class Transfer
    {
        public int Id { get; set; }
        public typeTransfer typeTransFer { get; set; }
        public double ValueTransfer { get; set; }
        public int IdbankAccount { get; set; }
        public int IdBank { get; set; }
        public int IdClient { get; set; }                 
    }
}