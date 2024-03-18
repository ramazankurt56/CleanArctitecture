using AutoMapper;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAll;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using EntityFrameworkCorePagination.Nuget.Pagination;
using GenericRepository;

namespace CleanArchitecture.Persistence.Services;
public class CarService(IMapper _mapper,ICarRepository carRepository,IUnitOfWork unitOfWork) : ICarService
{
    public async Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken)
    {
        Car car = _mapper.Map<Car>(request);
        //await _context.Set<Car>().AddAsync(car,cancellationToken);
        //await _context.SaveChangesAsync(cancellationToken);
        await carRepository.AddAsync(car,cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

    }

    public async Task<PaginationResult<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Car> cars = await carRepository
            .GetWhere(p=> p.Name.ToLower().Contains(request.Search.ToLower()))
            .OrderBy(p=>p.Name)
            .ToPagedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return cars;
    }
}
