namespace Domain.Dto.v1
{
    public class ClientPersonDto
    {
        public ClientPersonDto()
        { }
        public ClientPersonDto(int id, int idPerson, string name, string lastName, string cpf, string cNPJ, string telephone, string adress)
        {
            Id = id;
            IdPerson = idPerson;
            Name = name;
            LastName = lastName;
            Cpf = cpf;
            CNPJ = cNPJ;
            Telephone = telephone;
            Adress = adress;
        }
        public int Id { get; set; }
        public int IdPerson { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public string CNPJ { get; set; }
        public string Telephone { get; set; }
        public string Adress { get; set; }
    }
}
