﻿using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Persistence.Context;
using GenericRepository;

namespace CleanArchitecture.Persistence.Respositories;
public sealed class UserRoleRepository : Repository<UserRole, AppDbContext>, IUserRoleRepository
{
    public UserRoleRepository(AppDbContext context) : base(context)
    {
    }
}
