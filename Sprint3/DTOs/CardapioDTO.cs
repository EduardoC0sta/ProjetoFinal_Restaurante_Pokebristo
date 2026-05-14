using System.ComponentModel.DataAnnotations;

namespace Sprint3.DTOs
{
    public record CardapioDTO(
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(40)]
        string Nome,

        [Required(ErrorMessage = "A descrição é obrigatória")]
        string Descricao,

        [Range(0.01, 10000)]
        decimal Preco
    );
}