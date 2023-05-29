using System.ComponentModel.DataAnnotations;

namespace TccMvc.Models
{
    public class Cliente
    {
        public int Id { get; set; }
       
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }
        
        public string Telefone { get; set; }
        
        public string CEP { get; set; }
        
        public string Bairro { get; set; }
        
        public string Rua { get; set; }
        public string Numero { get; set; }
        public List<Aluguel> Alugueis { get; set; }
    }
}
