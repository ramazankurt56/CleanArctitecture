using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Entities;
public sealed class Car:Entity 
{
    public string Name { get; set; }=string.Empty;
    public string Model { get; set; } = string.Empty; 
    public int EnginePower { get; set; }

}
