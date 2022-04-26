namespace BasicAccountOperations.Domain.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string Number { get; set; }
        public string Cep { get; set; }            
    }
}