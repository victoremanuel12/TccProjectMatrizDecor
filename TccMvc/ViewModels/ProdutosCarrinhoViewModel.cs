using TccMvc.Models;

namespace TccMvc.ViewModel
{
    public class ProdutosCarrinhoViewModel
    {
        public List<(Produto Produto, int Quantidade)> CarrinhoDeComprasItems { get; set; }
        public decimal ValorTotalCarrinhoCompra { get; set; }
       

        

    }
}
