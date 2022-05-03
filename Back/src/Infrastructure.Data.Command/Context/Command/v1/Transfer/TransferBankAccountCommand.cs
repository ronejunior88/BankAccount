using Domain.Dto.v1;
using Infrastructure.Data.Command.Context.Interfaces.v1.Transfer;
using Infrastructure.Data.Context.Interfaces.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Command.v1.Transfer
{
    public class TransferBankAccountCommand : ITransferBankAccountInterface
    {
        public async Task<JsonResult> GetTransferById(IBootstrapper bootstrapper, IConfiguration configuration, int idTransfer)
        {
            TransferBankAccountIdDto TbADto;

            using (SqlCommand _command = bootstrapper.CreateCommand())
            {
                _command.CommandText = "[dbo].[Transfer_SelectById] @Id";
                _command.Parameters.Add("@Id", SqlDbType.Int).Value = idTransfer;

                using (SqlDataReader reader = _command.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        reader.Read();
                        TbADto = new TransferBankAccountIdDto(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(4));
                        return new JsonResult(TbADto);
                    }
                }
                _command.Connection.Close();
                return null;
            }
        }

        public async Task<JsonResult> GetTransferByClientId(IBootstrapper bootstrapper, IConfiguration configuration, int idClient)
        {
            TransferBankAccountIdClientDto TbADto;

            using (SqlCommand _command = bootstrapper.CreateCommand())
            {
                _command.CommandText = "[dbo].[TransferClient_SelectById] @Id";
                _command.Parameters.Add("@Id", SqlDbType.Int).Value = idClient;

                using (SqlDataReader reader = _command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        TbADto = new TransferBankAccountIdClientDto(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDecimal(4), reader.GetString(5), reader.GetString(6),reader.GetString(7),reader.GetString(8));
                        return new JsonResult(TbADto);
                    }
                }
                _command.Connection.Close();
                return null;
            }
        }

        public async Task<JsonResult> GetTransferAll(IBootstrapper bootstrapper, IConfiguration configuration)
        {
            TransferBankAccountAllDto TbADto;

            using (SqlCommand _command = bootstrapper.CreateCommand())
            {
                _command.CommandText = "[dbo].[TransferAll_Select]";

                using (SqlDataReader reader = _command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        TbADto = new TransferBankAccountAllDto(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDecimal(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8));
                        return new JsonResult(TbADto);
                    }
                }
                _command.Connection.Close();
                return null;
            }
        }
    }
}
