using AutoMapper;
using Domain.Dto.v1;
using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Command.v1.Bank;
using Infrastructure.Data.Command.Context.Interfaces.v1.Bank;
using Infrastructure.Data.Command.Context.Interfaces.v1.TransferBank;
using Infrastructure.Data.Context.Interfaces.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Command.v1.TransferBank
{
    public class TransferBankAccountCommand : ITransferBankAccountInterface
    {
        private readonly IMapper _mapper;
        public TransferBankAccountCommand(IMapper mapper)
        {
            _mapper = mapper;
        }

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

        public async Task<Transfer> InsertTransferBankAccount(IBootstrapper bootstrapper, IConfiguration configuration, Transfer transfer, BankAccountDto bankAccount)
        {
            BankAccountCommand bankAccountCommand = new BankAccountCommand();

            decimal deposit;

            if (transfer.TypeTransFer == "Deposito")
            {
                deposit = bankAccount.Balance + transfer.ValueTransfer;
            }else if (transfer.TypeTransFer == "Transferencia" || transfer.TypeTransFer == "Saque")
            {
                if(bankAccount.Balance > 0 && bankAccount.Balance - transfer.ValueTransfer >= 0)
                {
                    deposit = bankAccount.Balance - transfer.ValueTransfer;
                }
                else
                {
                    return null;
                }                       
            }
            else
            {
                return null;
            }

            using (SqlCommand _command = bootstrapper.CreateCommand())
            {
                _command.CommandText = "[dbo].[Insert_Transfer] @IdBankAccount, @ValueTransfer, @TypeTransfer";
                _command.Parameters.Add("@IdBankAccount", SqlDbType.Int).Value = transfer.IdBankAccount;
                _command.Parameters.Add("@ValueTransfer", SqlDbType.Decimal).Value = transfer.ValueTransfer;
                _command.Parameters.Add("@TypeTransfer", SqlDbType.VarChar).Value = transfer.TypeTransFer;
                int Id;
                if (int.TryParse(_command.ExecuteScalar().ToString(), out Id))
                {
                    transfer.IdBankAccount = Id;
                }
                _command.Connection.Close();
            }
            
            await bankAccountCommand.UpdateBankAccount_BalanceByTransfer(bootstrapper, configuration, bankAccount.Id, deposit);

            return transfer;           
        }
    }
}
