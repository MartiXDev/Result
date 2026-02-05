using System;

namespace MartiX.Result.Sample.Core.DTOs;

public class CreatePersonRequestDto
{
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
}