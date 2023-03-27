using System.Text.Json.Serialization;
using BaseProject.Domain.Enums;

namespace BaseProject.Domain.Dtos;

public record UpdateEmployeeStatusDto(EmployeeStatus Status);