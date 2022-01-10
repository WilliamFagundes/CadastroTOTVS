using API.ViewModels;
using AutoMapper;
using Business.Models;

namespace API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
        }

    }
}
