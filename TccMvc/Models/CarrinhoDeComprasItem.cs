using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TccMvc.Models
{
    public class CarrinhoDeComprasItem
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int ClienteId { get; set; }
        public int Quantidade { get; set; }

    }
}
