using AutoMapper;

namespace Agenda.WebApi.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper mapper { get; private set; }
        public static IMapper RegisterMappings()
        {
            var _mapper = new MapperConfiguration((mapper) =>
            {
                mapper.AddProfile<DomainToViewModel>();
                mapper.AddProfile<ViewModelToDomain>();
            });

            mapper = _mapper.CreateMapper();
            return _mapper.CreateMapper();
        }
    }
}