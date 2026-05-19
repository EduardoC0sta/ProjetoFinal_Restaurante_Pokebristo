namespace Sprint3.DTOs
{
    public class PedidoDTO
    {
        public int IdCliente { get; set; }
        public int IdFuncionario { get; set; }
        public string? StatusPedido { get; set; }

        // Ele vai usar a classe que já está definida no outro arquivo sem dar erro
        public List<ItemCarrinhoDTO> Itens { get; set; } = new List<ItemCarrinhoDTO>();
    }
}