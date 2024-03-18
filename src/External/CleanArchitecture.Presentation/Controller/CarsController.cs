using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAll;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Presentation.Abstraction;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controller;
public sealed class CarsController : ApiController
{
    public CarsController(IMediator mediator) : base(mediator){}

    [HttpPost]
    public async Task<IActionResult> Create(CreateCarCommand request,CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllCarQuery   request, CancellationToken cancellationToken)
    {
        PaginationResult<Car> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

}
