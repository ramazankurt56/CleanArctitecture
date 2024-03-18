using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAll;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
public sealed class GetAllCarQueryHandler(ICarService carService) : IRequestHandler<GetAllCarQuery, PaginationResult<Car>>
{
    public async Task<PaginationResult<Car>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Car> cars = await carService.GetAllAsync(request,cancellationToken);
        return cars;
    }
}
