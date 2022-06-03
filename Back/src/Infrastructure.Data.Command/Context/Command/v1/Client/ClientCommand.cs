using Domain.Dto.v1;
using Domain.Entities.v1;
using Infrastructure.Data.Command.Interfaces.v1.Client;
using Infrastructure.Data.Context.Interfaces.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Command.v1.Client
{
    public class ClientCommand : IClient
    {

        public async Task<Person> InsertPerson(IBootstrapper bootstrapper, IConfiguration configuration, Person person)
        {
            using (SqlCommand _command = bootstrapper.CreateCommand())
            {
                _command.CommandText = "EXEC [dbo].[Insert_Person] @name, @LastName, @Cpf, @CNPJ, @telephone, @adress";
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
                _command.Connection.Close();
                return person;

            }
        }

        public async Task<JsonResult> GetClientById(IBootstrapper bootstrapper, IConfiguration configuration, int client)
        {
            ClientPersonDto cpDto = null;

            using (SqlCommand _command = bootstrapper.CreateCommand())
            {
                _command.CommandText = "EXEC [dbo].[Client_SelectById] @Id";
                _command.Parameters.Add("@Id", SqlDbType.Int).Value = client;

                using (SqlDataReader reader = _command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        cpDto = new ClientPersonDto(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7));
                        return new JsonResult(cpDto);
                    }
                }
                _command.Connection.Close();
                return new JsonResult(cpDto);
            }
        }
    }
}
