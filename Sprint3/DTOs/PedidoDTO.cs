namespace Sprint3.DTOs
{
    public class PedidoDTO
    {
        public int IdCliente { get; set; }
        public int IdFuncionario { get; set; }
        public string? StatusPedido { get; set; }
        // Lista de itens que o cliente quer comprar
        public List<ItemPedidoDTO> Itens { get; set; } = new List<ItemPedidoDTO>();
    }
}