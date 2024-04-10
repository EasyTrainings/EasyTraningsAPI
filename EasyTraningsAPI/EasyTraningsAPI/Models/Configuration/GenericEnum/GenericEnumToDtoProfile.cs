using System;
using AutoMapper;

namespace EasyTraningsAPI.Models.Configuration.GenericEnum;

public class GenericEnumToDtoProfile: Profile
{
    public GenericEnumToDtoProfile()
    {
        CreateMap(typeof(Enum), typeof(EnumDto))
            .ConvertUsing(typeof(GenericEnumToDtoConverter));
    }
}