using AutoMapper;
using FonTech.Application.Mapping;

namespace FonTech.Tests.Configurations;

public static class MapperConfiguration
{
    public static IMapper GetMapperConfiguration()
    {
        var mockMapper = new AutoMapper.MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ReportMapping());
        });
        return mockMapper.CreateMapper();
    }
}