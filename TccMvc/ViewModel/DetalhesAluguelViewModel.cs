using TccMvc.Models;

namespace TccMvc.ViewModel
{
    public class DetalhesAluguelViewModel
    {
        public Cliente Cliente { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }

        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }


    }
}
