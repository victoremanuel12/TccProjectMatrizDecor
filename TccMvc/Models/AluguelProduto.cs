namespace TccMvc.Models
{
    public class AluguelProduto
    {
        public int Id { get; set; }
        public Aluguel Aluguel { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
