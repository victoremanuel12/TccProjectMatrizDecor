using TccMvc.Models;

namespace TccMvc.ViewModel
{
    public class ProdutoListViewModel
    {
       public IEnumerable<Produto> Produtos { get; set; }
       public string CategoriaAtual { get; set; }
        public IEnumerable<Categoria> Categorias { get; set; }
        public Aluguel Aluguel { get; set; }
    }
}
