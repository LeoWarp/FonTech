using AutoMapper;
using FonTech.Domain.Dto.Role;
using FonTech.Domain.Entity;

namespace FonTech.Application.Mapping;

public class RoleMapping : Profile
{
    public RoleMapping()
    {
        CreateMap<Role, RoleDto>().ReverseMap();
    }
}