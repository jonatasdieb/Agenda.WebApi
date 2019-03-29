using Agenda.Domain.Entities;
using Agenda.WebApi.ViewModels;
using AutoMapper;

namespace Agenda.WebApi.AutoMapper
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<PessoaViewModel, Pessoa>();
            CreateMap<PessoaMarcadorViewModel, PessoaMarcador>();           
           
            CreateMap<ContatoViewModel, Contato>();
            CreateMap<ContatoTipoViewModel, ContatoTipo>();
            //CreateMap<List<ContatoViewModel>, List<Contato>>();

            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<EnderecoTipoViewModel, EnderecoTipo>();
           // CreateMap<List<EnderecoViewModel>, List<Endereco>>();


        }
    }
}