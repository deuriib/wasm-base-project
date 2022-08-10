using Ardalis.SmartEnum;

namespace WasmBaseProject.Domain.Enums;

public abstract class EmployeeStatus : SmartEnum<EmployeeStatus, bool>
{
    public static readonly EmployeeStatus Inactive = new InactiveStatus();
    public static readonly EmployeeStatus Active = new ActiveStatus();

    private EmployeeStatus(string name, bool value) : base(name, value)
    {
    }


    private sealed class InactiveStatus : EmployeeStatus
    {
        public InactiveStatus() : base("Inactive", false)
        {
        }
    }

    private sealed class ActiveStatus : EmployeeStatus
    {
        public ActiveStatus() : base("Active", true)
        {
        }
    }
}