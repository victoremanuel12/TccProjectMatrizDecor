using TccMvc.Context;
using TccMvc.Models;
using TccMvc.Repository.Interfaces;

namespace TccMvc.Repository
{
    public class ClienteRepository: Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
