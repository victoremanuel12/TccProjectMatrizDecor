using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace TccMvc.Models
{
    public class Aluguel
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public virtual int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual List<AluguelProduto> AluguelProdutos { get; set; }
    }
}
