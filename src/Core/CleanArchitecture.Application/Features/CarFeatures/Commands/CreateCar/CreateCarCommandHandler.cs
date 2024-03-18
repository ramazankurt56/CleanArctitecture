using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
public sealed class CreateCarCommandHandler(ICarService _carService) : IRequestHandler<CreateCarCommand
    , MessageResponse>
{
    public async Task<MessageResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        await _carService.CreateAsync(request, cancellationToken);
        return new("Araç Başarıyla Kaydedildi!");
    }
}
