using AutoMapper;
using Venu.Identity.Domain;
using Venu.Identity.Dtos;

namespace Venu.Identity.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<AuthenticateUserDto, User>();
            CreateMap<RegisterUserDto, User>();
            CreateMap<User, UserInfoDto>();
            CreateMap<UpdateUserDto, User>();
        }
    }
}