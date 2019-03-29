using Agenda.Domain.Entities;
using Agenda.WebApi.ViewModels;
using AutoMapper;

namespace Agenda.WebApi.AutoMapper
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<Pessoa, PessoaViewModel>();
            CreateMap<PessoaMarcador, PessoaMarcadorViewModel>();           

            CreateMap<Contato, ContatoViewModel>();
            CreateMap<ContatoTipo, ContatoTipoViewModel>();           
          
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<EnderecoTipo, EnderecoTipoViewModel>();
           
        }
    }
}