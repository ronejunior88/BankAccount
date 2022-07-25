using AutoMapper;
using Infrastructure.Data.Query.Interfaces.v1;
using Infrastructure.Data.Repository.Interfaces.v1;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Query.Queries.v1.Client.ClientSelectById
{
    public class ClientSelectByIdHandler : IClientSelectById, IRequestHandler<ClientSelectByIdRequest, ClientSelectByIdResponse>
    {
        private readonly IMapper _mapper;
        private IClientRepository _clientRepository;
        public ClientSelectByIdHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;         
        }
        public ClientSelectByIdHandler()
        { }
        public async Task<ClientSelectByIdResponse> Handle(ClientSelectByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await GetClientByIdAsync(request.Id);
            return result;
        }
        public async Task<ClientSelectByIdResponse> GetClientByIdAsync(int client)
        {
            var result = await _clientRepository.GetClientByIdAsync(client);
            return _mapper.Map<ClientSelectByIdResponse>(result);
        }    
    }
}
