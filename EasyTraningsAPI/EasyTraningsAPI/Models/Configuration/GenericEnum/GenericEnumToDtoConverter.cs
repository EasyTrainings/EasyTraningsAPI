using System;

namespace EasyTraningsAPI.Models.Configuration.GenericEnum;

using AutoMapper;

public class GenericEnumToDtoConverter : ITypeConverter<Enum, EnumDto>
{
    public EnumDto Convert(Enum source, EnumDto destination, ResolutionContext context)
    {
        return new EnumDto
        {
            Id = System.Convert.ToInt32(source),
            Name = source.ToString()
        };
    }
}