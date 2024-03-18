﻿using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Persistence.Context;
using GenericRepository;

namespace CleanArchitecture.Persistence.Respositories;
public sealed class CarRepository : Repository<Car, AppDbContext>, ICarRepository
{
    public CarRepository(AppDbContext context) : base(context)
    {
    }
}
