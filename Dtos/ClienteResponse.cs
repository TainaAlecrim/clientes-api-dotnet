namespace ClientesApi.DTOs
{
    public class ClienteResponse
    {
        public int? Id { get; set; }
        public string? Nome { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
