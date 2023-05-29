using TccMvc.Models;

namespace TccMvc.Repository.Interfaces
{
    public interface IUnitOfWork
    {

        IProdutoRespository ProdutoRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }
        IClienteRepository ClienteRepository { get; }
        ICarrinhoDeComprasRepository CarrinhoDeComprasRepository { get; }
        IAluguelRepository AluguelRepository { get; }

        Task Commit();

    }
}
