using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprint3.Models
{
    [Table("item_pedido")]
    public class ItemPedido
    {
        [Key]
        [Column("id_item_pedido")]
        public int IdItemPedido { get; set; }

        [Column("id_pedido")]
        public int IdPedido { get; set; }

        [Column("id_cardapio")]
        public int IdCardapio { get; set; }

        [Column("quantidade")]
        public int Quantidade { get; set; }

        // Navegação
        [ForeignKey("IdPedido")]
        public virtual Pedido? Pedido { get; set; }

        [ForeignKey("IdCardapio")]
        public virtual Cardapio? Cardapio { get; set; }
    }
}