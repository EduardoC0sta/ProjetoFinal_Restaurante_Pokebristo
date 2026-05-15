using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprint3.Models
{
    [Table("pedido")]
    public class Pedido
    {
        [Key]
        [Column("id_pedido")]
        public int IdPedido { get; set; }

        [Column("id_cliente")]
        public int IdCliente { get; set; }

        // Propriedade de Navegação para o Cliente
        [ForeignKey("IdCliente")]
        public virtual Cliente? Cliente { get; set; }

        [Column("id_funcionario")]
        public int IdFuncionario { get; set; }

        // Propriedade de Navegação para o Funcionário
        [ForeignKey("IdFuncionario")]
        public virtual Funcionario? Funcionario { get; set; }

        [Column("data_pedido")]
        public DateTime DataPedido { get; set; } = DateTime.Now;

        [Column("status_pedido")]
        public string? StatusPedido { get; set; }

        public virtual ICollection<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
    }
}