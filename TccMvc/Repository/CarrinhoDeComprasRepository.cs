using TccMvc.Context;
using TccMvc.Models;
using TccMvc.Repository.Interfaces;

namespace TccMvc.Repository
{
    public class CarrinhoDeComprasRepository : Repository<CarrinhoDeComprasItem>, ICarrinhoDeComprasRepository
    {
        public CarrinhoDeComprasRepository(AppDbContext context) : base(context)
        {
        }

        public void AdiconarItemAoCarrinho(int produtoId, int clienteId)
        {

            var carrinhoDeCompraItem = _context.CarrinhoDeCompras
            .Where(c => c.ClienteId == clienteId && c.ProdutoId == produtoId)
            .FirstOrDefault();
            if (carrinhoDeCompraItem == null)
            {
                carrinhoDeCompraItem = new CarrinhoDeComprasItem();
                carrinhoDeCompraItem.ProdutoId = produtoId;
                carrinhoDeCompraItem.ClienteId = clienteId;
                carrinhoDeCompraItem.Quantidade = 1;
                _context.CarrinhoDeCompras.Add(carrinhoDeCompraItem);
            }
            else
            {
                carrinhoDeCompraItem.Quantidade++;
            }
        }



        public List<(Produto Produto, int Quantidade)> BuscarItensQuantidadeDoCarrinho(int clienteId)
        {
            var itensCarrinho = _context.CarrinhoDeCompras.Where(c => c.ClienteId == clienteId).ToList();
            if (!itensCarrinho.Any())
            {
                return new List<(Produto,int Quantidade)>();
            }
            var produtosIds = itensCarrinho.Select(p => p.ProdutoId).ToList();
            var quantidadeProdutos = itensCarrinho.Select(p => p.Quantidade).ToList();
            var produtos = _context.Produto.Where(p => produtosIds.Contains(p.Id)).ToList();
            var resultado = new List<(Produto Produto, int Quantidade)>();

            for (int i = 0; i < produtos.Count(); i++)
            {
                resultado.Add((produtos[i], quantidadeProdutos[i]));
            }
            return resultado;
        }

        public decimal CarrinhoCompraTotal(int clienteId)
        {
            var itensCarrinho = _context.CarrinhoDeCompras
                .Where(c => c.ClienteId == clienteId)
                .ToList();
            var produtosIds = itensCarrinho.Select(p => p.ProdutoId).ToList();
            var quantidadeProdutos = itensCarrinho.Select(p => p.Quantidade).ToList();
            var valorTotal = 0;
            for (int i = 0; i < itensCarrinho.Count; i++)
            {
                var produto = _context.Produto.FirstOrDefault(p => p.Id == produtosIds[i]);
                var subtotal = produto.Preco * quantidadeProdutos[i];
                valorTotal += subtotal;
            }
            return valorTotal;
        }

        public void ExcluirItemDoCarrinho(int produtoId, int clienteId)
        {
            var carrinhoDeComprasItem = _context.CarrinhoDeCompras.FirstOrDefault(c => c.ProdutoId == produtoId && c.ClienteId == clienteId);

            _context.CarrinhoDeCompras.Remove(carrinhoDeComprasItem);

        }

        public  void ExcluirTodosOsItensDoCarrinho(int clienteId)
        {
            var itensCarrinho = _context.CarrinhoDeCompras
                .Where(c => c.ClienteId == clienteId)
                .ToList();
            _context.RemoveRange(itensCarrinho);
            _context.SaveChanges();
        }




    }
}
