using Domain.Entities.v1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Command.Context.Command.v1.Clients
{
    public class ClientResponse
    {
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
