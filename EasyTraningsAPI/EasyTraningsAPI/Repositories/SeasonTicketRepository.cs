using EasyTraningsAPI.DbContext;
using EasyTraningsAPI.Repositories.Generic;
using EasyTraningsAPI.Repositories.Interfaces;

namespace EasyTraningsAPI.Repositories;

public class SeasonTicketRepository: Repository<SeasonTicket.Entities.SeasonTicket>, ISeasonTicketRepository
{
    public SeasonTicketRepository(AppDbContext context) : base(context){}
}