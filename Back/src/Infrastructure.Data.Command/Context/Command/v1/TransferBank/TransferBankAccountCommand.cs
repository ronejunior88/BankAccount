using AutoMapper;
using Domain.Dto.v1;
using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Command.v1.Bank;
using Infrastructure.Data.Command.Context.Interfaces.v1.Bank;
using Infrastructure.Data.Command.Context.Interfaces.v1.TransferBank;
using Infrastructure.Data.Command.Context.Queues.v1;
using Infrastructure.Data.Context.Interfaces.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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
            Transfer TbADto;

            using (SqlCommand _command = bootstrapper.CreateCommand())
            {
                _command.CommandText = "[dbo].[Transfer_SelectById] @Id";
                _command.Parameters.Add("@Id", SqlDbType.Int).Value = idTransfer;

                using (SqlDataReader reader = _command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        TbADto = new Transfer(reader.GetInt32(0), reader.GetInt32(1), reader.GetDecimal(2), reader.GetString(3));
                        return new JsonResult(TbADto);
                    }
                }
                _command.Connection.Close();
                return null;
            }
        }

        public async Task<List<TransferBankAccountIdClientDto>> GetTransferByClientId(IBootstrapper bootstrapper, IConfiguration configuration, int idClient)
        {

            List<TransferBankAccountIdClientDto> TBaCdto = new List<TransferBankAccountIdClientDto>();

            using (SqlCommand _command = bootstrapper.CreateCommand())
            {
                _command.CommandText = "[dbo].[TransferClient_SelectById] @Id";
                _command.Parameters.Add("@Id", SqlDbType.Int).Value = idClient;

                using (SqlDataReader reader = _command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            TBaCdto.Add(new TransferBankAccountIdClientDto(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetDecimal(7)));

                        }
                        return TBaCdto;
                    }
                }
                _command.Connection.Close();
            }
            return TBaCdto;
        }

        public async Task<List<TransferBankAccountAllDto>> GetTransferAll(IBootstrapper bootstrapper, IConfiguration configuration)
        {
            List<TransferBankAccountAllDto> TbADto = new List<TransferBankAccountAllDto>();

            using (SqlCommand _command = bootstrapper.CreateCommand())
            {
                _command.CommandText = "[dbo].[TransferAll_Select]";

                using (SqlDataReader reader = _command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            TbADto.Add(new TransferBankAccountAllDto(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetDecimal(7)));
                        }
                        return (TbADto);
                    }
                }
                _command.Connection.Close();
                return null;
            }
        }

        public async Task<Transfer> InsertTransferBankAccount(IBootstrapper bootstrapper, IConfiguration configuration, Transfer transfer, BankAccountDto bankAccount)
        {
            BankAccountCommand bankAccountCommand = new BankAccountCommand();


            if (transfer.ValueTransfer > 0)
            {
                switch (transfer.TypeTransFer)
                {
                    case "Deposito":
                        bankAccount.Balance = bankAccount.Balance + transfer.ValueTransfer;
                        break;
                    case "Transferencia":
                        bankAccount.Balance = transferWithdraw(transfer, bankAccount);
                        break;
                    case "Saque":
                        bankAccount.Balance = transferWithdraw(transfer, bankAccount);
                        break;
                    default:
                        return null;
                }  
                    TransferQueues queues = new TransferQueues();
                    var message = JsonConvert.SerializeObject(transfer);
                    queues.Connect(message);
                    //insertTransfer(bootstrapper, transfer);
                    //await bankAccountCommand.UpdateBankAccount_BalanceByTransfer(bootstrapper, configuration, bankAccount.Id, deposit);              
                return transfer;

            }
            return null;
        }

        public decimal transferWithdraw(Transfer transfer, BankAccountDto bankAccount)
        {
            if (bankAccount.Balance > 0 && bankAccount.Balance - transfer.ValueTransfer >= 0)
            {
                return bankAccount.Balance - transfer.ValueTransfer;
            }
            return 0;
        }

        public void insertTransfer(IBootstrapper bootstrapper, Transfer transfer) 
        {
            using (SqlCommand _command = bootstrapper.CreateCommand())
            {
                _command.CommandText = "[dbo].[Insert_Transfer] @IdBankAccount, @ValueTransfer, @TypeTransfer";
                _command.Parameters.Add("@IdBankAccount", SqlDbType.Int).Value = transfer.IdBankAccount;
                _command.Parameters.Add("@ValueTransfer", SqlDbType.Decimal).Value = transfer.ValueTransfer;
                _command.Parameters.Add("@TypeTransfer", SqlDbType.VarChar).Value = transfer.TypeTransFer;
                int Id;
                if (int.TryParse(_command.ExecuteScalar().ToString(), out Id))
                {
                    transfer.Id = Id;
                }
                _command.Connection.Close();
            }
        }
    }
}
