using AutoMapper;
using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Interfaces.v1.TransferBank;
using Infrastructure.Data.Command.Context.Rabbit.v1;
using Infrastructure.Data.Repository.Interfaces.v1;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Command.v1.TransferBank.TransferBankAccount
{
    public class TransferBankAccountHandler : ITransferBankAccount, IRequestHandler<TransferBankAccountRequest, TransferBankAccountResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private IBankAccountRepository _bankAccountRepository;
        public TransferBankAccountHandler(IConfiguration configuration, IMapper mapper, IBankAccountRepository bankAccountRepository)
        {
            _configuration = configuration;
            _mapper = mapper;
            _bankAccountRepository = bankAccountRepository;
        }
        public TransferBankAccountHandler()
        { }
        public async Task<TransferBankAccountResponse> Handle(TransferBankAccountRequest request, CancellationToken cancellationToken)
        {
            var bankAccount = await _bankAccountRepository.GetBankAccountSelectByIdAsync(request.Transfer.IdBankAccount);
            return bankAccount != null && bankAccount.Id > 0 ? await InsertTransferBankAccountAsync(request.Transfer) : null;
        }
        public async Task<TransferBankAccountResponse> InsertTransferBankAccountAsync(Transfer transfer)
        {
            TransferQueues queues = new TransferQueues();
            var message = JsonConvert.SerializeObject(transfer);
            queues.Send(_configuration, message);
            return _mapper.Map<TransferBankAccountResponse>(transfer);
        }        
    }
}
