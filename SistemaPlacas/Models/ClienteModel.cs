using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaPlacas.Models
{
    public class ClienteModel
    {
        [Key]
        public int ClienteId { get; set; }  

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; } 
        [Required(ErrorMessage = "O email é obrigatório."),
        EmailAddress]
        public string Email { get; set; }

        [Phone(ErrorMessage = "O telefone deve ser um número válido.")]
        public string Telefone { get; set; }  
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public List<PedidoModel> Pedidos { get; set; } = new List<PedidoModel>();
    }
}
