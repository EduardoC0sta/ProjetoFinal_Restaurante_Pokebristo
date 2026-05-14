using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprint3.Models
{
    [Table("cliente")]
    public class Cliente
    {
        [Key][Column("id_cliente")] public int IdCliente { get; set; }
        [Required][Column("cpf")][MaxLength(15)] public string? Cpf { get; set; }
        [Required][Column("nome")][MaxLength(60)] public string? Nome { get; set; }
    }
}