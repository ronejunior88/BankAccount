using BasicAccountOperations.Domain.Model;
using Infrastructure.Data.Command.Interfaces.v1;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Command.v1
{
    public class ClientCommand : IClientCommandInterface
    {
         
        public async Task<Person> InsertPerson(IBootstrapper bootstrapper,IConfiguration configuration,Person person)
        {       
                using (SqlCommand _command = bootstrapper.CreateCommand())
                {
                    var sql = _command.CommandText = "EXEC [dbo].[Insert_Person] @name, @LastName, @Cpf, @CNPJ, @telephone, @adress";
                    _command.Parameters.Add("@name", SqlDbType.VarChar).Value = person.Name;
                    _command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = person.LastName;
                    _command.Parameters.Add("@Cpf", SqlDbType.VarChar).Value = person.Cpf;
                    _command.Parameters.Add("@CNPJ", SqlDbType.VarChar).Value = person.Cnpj;
                    _command.Parameters.Add("@telephone", SqlDbType.VarChar).Value = person.Telephone;
                    _command.Parameters.Add("@adress", SqlDbType.VarChar).Value = person.Adress;
                    int Id;
                    if (int.TryParse(_command.ExecuteScalar().ToString(), out Id))
                    {
                        person.Id = Id;
                    }
                    return person;
                }
        }        
    }
}
