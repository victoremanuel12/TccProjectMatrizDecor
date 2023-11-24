using TccMvc.Context;
using TccMvc.Models;
using TccMvc.Repository.Interfaces;

namespace TccMvc.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRespository
    {
        public ProdutoRepository(AppDbContext context) : base(context)
        {
        }

       
    }
}
