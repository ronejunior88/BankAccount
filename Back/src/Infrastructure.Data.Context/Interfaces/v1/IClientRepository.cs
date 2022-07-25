using Domain.Dto.v1;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository.Interfaces.v1
{
    public interface IClientRepository
    {
        Task<ClientPersonDto> GetClientByIdAsync(int client);
    }
}
