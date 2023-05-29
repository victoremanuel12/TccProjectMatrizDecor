using TccMvc.Models;

namespace TccMvc.Repository.Interfaces
{
    public interface ICarrinhoDeComprasRepository : IRepository<CarrinhoDeComprasItem>
    {
        public List<(Produto Produto, int Quantidade)> BuscarItensQuantidadeDoCarrinho(int clienteId);
        public decimal CarrinhoCompraTotal(int clienteId);
        public void ExcluirTodosOsItensDoCarrinho(int clienteId);
        void AdiconarItemAoCarrinho(int produtoId, int clienteId);
        public void ExcluirItemDoCarrinho(int produtoId, int clienteId);
    }
}
