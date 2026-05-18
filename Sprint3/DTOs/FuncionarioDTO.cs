namespace Sprint3.DTOs
{
    public class FuncionarioDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string? Cargo { get; set; }
        public decimal Salario { get; set; }
        public string Status { get; set; } = "Empregado";
    }
}