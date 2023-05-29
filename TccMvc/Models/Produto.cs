using System.ComponentModel.DataAnnotations;

namespace TccMvc.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Preco { get; set; }
        public string DescricaoDetalhada { get; set; }
        public string ImagemUrl { get; set; }
        public bool IsDisponivel { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual List<ImagemProduto> Imagens { get; set; }
    }
}
