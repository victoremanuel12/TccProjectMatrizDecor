using TccMvc.Models;

namespace TccMvc.ViewModel
{
    public class HistoricoAlugueisViewModel
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }

        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public int AluguelId { get; set; }
        public List<Produto> Produtos { get; set; }

        
    }
}
