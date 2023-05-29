using TccMvc.Context;
using TccMvc.Models;
using TccMvc.Repository.Interfaces;

namespace TccMvc.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
