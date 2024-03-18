using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAll;
public sealed record GetAllCarQuery(
    int PageNumber=1,
    int PageSize=10,
    string Search=""):IRequest<PaginationResult<Car>>;
