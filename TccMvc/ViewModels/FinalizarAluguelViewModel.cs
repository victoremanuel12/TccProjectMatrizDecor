using System.ComponentModel.DataAnnotations;

namespace TccMvc.ViewModels
{
    public class FinalizarAluguelViewModel
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MinLength(2, ErrorMessage = "O campo Nome deve ter no mínimo 2 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        [MinLength(7, ErrorMessage = "O campo Telefone deve ter no mínimo 2 caracteres.")]
        [RegularExpression(@"^\d{2}\d{8,9}$", ErrorMessage = "O campo Telefone deve ser um número de telefone válido.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo CEP é obrigatório.")]
        [MinLength(8, ErrorMessage = "O campo CEP deve ter  8 caracteres.")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O campo Bairro é obrigatório.")]
        [MinLength(2, ErrorMessage = "O campo Bairro deve ter no mínimo 2 caracteres.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo Rua é obrigatório.")]
        [MinLength(2, ErrorMessage = "O campo Rua deve ter no mínimo 2 caracteres.")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O campo Número é obrigatório.")]
        [MinLength( 1,ErrorMessage = "O campo Número deve ter no mínimo 2 caracteres.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O campo Data do Evento é obrigatório.")]
        [Display(Name = "Data do Evento")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [CustomDate(ErrorMessage = "A data do evento não pode ser a data de hoje ou anterior.")]
        public DateTime DataEvento { get; set; }

        [Required(ErrorMessage = "O campo Data de Devolução é obrigatório.")]
        [Display(Name = "Data de Devolução")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        public DateTime DataDevolucao { get; set; }
        public class CustomDateAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                DateTime currentDate = DateTime.Now.Date;
                DateTime selectedDate = (DateTime)value;

                if (selectedDate < currentDate.AddDays(1))
                {
                    return new ValidationResult(ErrorMessage);
                }

                return ValidationResult.Success;
            }
        }
    }
}
