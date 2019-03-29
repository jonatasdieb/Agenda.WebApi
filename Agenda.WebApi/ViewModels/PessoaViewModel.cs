using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Agenda.WebApi.ViewModels
{
    public class PessoaViewModel
    {

        public PessoaViewModel()
        {
            Contatos = new List<ContatoViewModel>();
            Enderecos = new List<EnderecoViewModel>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int MarcadorId { get; set; }

        [MinLength(2, ErrorMessage = "O nome é obrigatório e deve conter pelo menos {0} caracteres.")]
        [MaxLength(100, ErrorMessage = "O nome deve conter no máximo {0} caracteres.")]
        [Required]
        public string Nome { get; set; }

        public List<ContatoViewModel> Contatos { get; set; }

        public List<EnderecoViewModel> Enderecos { get; set; }

        public PessoaMarcadorViewModel Marcador { get; set; }

        public ContatoViewModel Contato { get; set; }
              
        public EnderecoViewModel Endereco { get; set; }

       
    }
}
