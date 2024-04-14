using EasyTraningsAPI.DbContext;
using EasyTraningsAPI.Repositories.Generic;
using EasyTraningsAPI.Repositories.Interfaces;

namespace EasyTraningsAPI.Repositories;

public class TranningRepository: Repository<Tranning.Entities.Tranning>, ITranningRepository
{
    public TranningRepository(AppDbContext context) : base(context){ }
}