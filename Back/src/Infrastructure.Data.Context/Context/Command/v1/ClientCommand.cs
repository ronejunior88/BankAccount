using BasicAccountOperations.Domain.Model;
using Infrastructure.Data.Context.Context.Interfaces;
using Infrastructure.Data.Context.Context.v1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Context.Context.Command.v1
{
    public class ClientCommand : IClientCommandInterface
    {
        private DbContext _context;

        public async Task<int> InsertPerson(Person person)
        {
            _context = new DbContext();
            _context.dbConnectionOpen();
            using (SqlCommand _command =  _context.CreateCommand())
            {
                var id = _command.CommandText = "EXEC [dbo].[Insert_Person] @name @lastname @Cpf @CNPJ @telephone @adress";
                _command.Parameters.Add("@name", SqlDbType.VarChar).Value = person.Name;
                _command.Parameters.Add("@lastname", SqlDbType.VarChar).Value = person.LastName;
                _command.Parameters.Add("@Cpf", SqlDbType.VarChar).Value = person.Cpf;
                _command.Parameters.Add("@CNPJ", SqlDbType.VarChar).Value = person.Cnpj;
                _command.Parameters.Add("@telephone", SqlDbType.VarChar).Value = person.Telephone;
                _command.Parameters.Add("@adress", SqlDbType.VarChar).Value = person.Adress;

                return Convert.ToInt32(id);
            }
        }        
    }
}
