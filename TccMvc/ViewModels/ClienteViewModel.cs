using System.ComponentModel.DataAnnotations;

namespace TccMvc.ViewModel
{
    public class ClienteViewModel
    {
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório, com no minimo 4 caracteres")]
        [MinLength(4,ErrorMessage ="A senha deve ter no minimo 4 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    
    }
}
