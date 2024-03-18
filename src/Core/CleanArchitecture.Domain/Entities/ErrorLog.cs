using CleanArchitecture.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public sealed class ErrorLog:Entity
{
    public string ErrorMessage { get; set; }=string.Empty;
    public string StackTrace { get; set; } = string.Empty;
    public string RequestPath { get; set; } = string.Empty;
    public string RequestMethod { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
}
