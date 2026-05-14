using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprint3.Models
{
    [Table("cardapio")]
    public class Cardapio
    {
        [Key]
        [Column("id_cardapio")]
        public int IdCardapio { get; set; }

        [Required(ErrorMessage = "O nome do prato é obrigatório.")]
        [MaxLength(40, ErrorMessage = "O nome deve ter no máximo 40 caracteres.")]
        [Column("nome")]
        public string Nome { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, 9999.99, ErrorMessage = "O preço deve ser maior que zero.")]
        [Column("preco")]
        public decimal Preco { get; set; }
    }
}