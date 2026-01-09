using System.ComponentModel.DataAnnotations;

namespace ClientesApi.Dtos
{
    public class ClienteRequest
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage = "Email inválido")]
        [Required(ErrorMessage = "O email é obrigatório")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Telefone inválido")]
        public string? Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
    }

}
