﻿using AutoMapper;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistence.Mappings;
public sealed class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCarCommand, Car>();
        CreateMap<RegisterCommand, AppUser>();
    }
}
