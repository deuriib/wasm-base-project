using AutoMapper;
using WasmBaseProject.Domain.Enums;

namespace WasmBaseProject.Adapters.Mappers;

public class EmployeeStatusConverter : IValueConverter<bool, EmployeeStatus>
{
    public EmployeeStatus Convert(bool sourceMember, ResolutionContext context)
    {
        return EmployeeStatus.FromValue(sourceMember);
    }
}