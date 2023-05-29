using TccMvc.Models;

namespace TccMvc.Repository.Interfaces
{
    public interface IAluguelRepository : IRepository<Aluguel>
    {
        public  List<Aluguel> GetAlugueisByCliente();
    }
}
