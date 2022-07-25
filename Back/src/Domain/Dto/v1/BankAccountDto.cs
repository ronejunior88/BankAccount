namespace Domain.Dto.v1
{
    public class BankAccountDto
    {
        public BankAccountDto()
        { }
        public BankAccountDto(int id, int idBank, int idClient, decimal balance, string typeAccount)
        {
            Id = id;
            IdBank = idBank;
            IdClient = idClient;
            Balance = balance;
            TypeAccount = typeAccount;
        }
        public int Id { get; set; }
        public int IdBank { get; set; }
        public int IdClient { get; set; }
        public decimal Balance { get; set; }
        public string TypeAccount { get; set; }
    }
}
