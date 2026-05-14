using System.ComponentModel.DataAnnotations;

namespace Sprint3.DTOs
{
    public record ClienteDTO(
        [Required] [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido")]
        string Cpf,

        [Required] [StringLength(60)]
        string Nome
    );
}