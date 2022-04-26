using System.Collections;
using System.Collections.Generic;

namespace BasicAccountOperations.Domain.Model
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Cpf { get; set; }

        public string Cnpj { get; set; }

        public string Telephone { get; set; }

        public IEnumerable<Address> IdAdress { get; set; }
    }
}