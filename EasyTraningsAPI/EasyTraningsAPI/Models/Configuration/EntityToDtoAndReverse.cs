using AutoMapper;
using EasyTraningsAPI.Models.DTOs;

namespace EasyTraningsAPI.Models.Configuration;

public class EntityToDtoAndReverse: Profile
{
    public EntityToDtoAndReverse()
    {
        CreateMap<User.Entities.User, UserDto>().ReverseMap();
        CreateMap<SeasonTicket.Entities.SeasonTicket, SeasonTicketDto>().ReverseMap();
        CreateMap<Tranning.Entities.Tranning, TranningDto>().ReverseMap();
    }
}