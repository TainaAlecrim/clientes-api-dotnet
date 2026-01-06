namespace ClientesApi.Dtos
{
    public class ClienteDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
                public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
    }

}
