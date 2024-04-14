using System;
using EasyTraningsAPI.DbContext;
using EasyTraningsAPI.Repositories.Generic;
using EasyTraningsAPI.Repositories.Interfaces;

namespace EasyTraningsAPI.Repositories;

public class UserRepository: Repository<User.Entities.User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context){}
}