using AutoMapper;
using FonTech.Domain.Dto.User;
using FonTech.Domain.Entity;

namespace FonTech.Application.Mapping;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}