using TccMvc.Models;

namespace TccMvc.Repository.Interfaces
{
    public interface IProdutosImagemRepository
    {
        IEnumerable<ImagemProduto> ImagensProduto { get; }
    }
}
