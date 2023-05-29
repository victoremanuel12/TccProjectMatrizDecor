using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using TccMvc.Context;
using TccMvc.Models;
using TccMvc.Repository.Interfaces;

namespace TccMvc.Repository
{
    public class AluguelRepository : Repository<Aluguel>, IAluguelRepository
    {
        public AluguelRepository(AppDbContext context) : base(context)
        {
        }

        public List<Aluguel> GetAlugueisByCliente()
        {
            var aluguelProduto =   _context.AluguelProduto
                  .Include(o => o.Aluguel)
                  .Include(o => o.Aluguel.Cliente)
                  .Include(o => o.Produto)
                  .ToList()
                  .GroupBy(o => o.Aluguel);

            return aluguelProduto.Select(o => o.Key).ToList();
        }
    }
}
