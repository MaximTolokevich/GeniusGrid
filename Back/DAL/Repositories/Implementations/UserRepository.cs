﻿using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementations
{
    public class UserRepository : EfRepository<UserDbEntry>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext) { }
    }
}
