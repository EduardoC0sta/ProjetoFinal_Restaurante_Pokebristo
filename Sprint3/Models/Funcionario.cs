using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprint3.Models
{
    [Table("funcionario")]
    public class Funcionario
    {
        [Key][Column("id_funcionario")] public int IdFuncionario { get; set; }
        [Required][Column("nome")] public string? Nome { get; set; }
        [Column("cargo")] public string? Cargo { get; set; } 
        [Column("salario")] public decimal Salario { get; set; }
        [Column("status")] public string? Status { get; set; }
    }
}