using AutoMapper;

namespace ToDo.Application.Mappers
{
    public class RegisterMapper
    {
        public static MapperConfiguration Register()
        {
            return new MapperConfiguration(m =>
            {
                m.AddProfile<DomainToViewModel>();
                m.AddProfile<ViewModelToDomain>();
            });
        }
    }
}
