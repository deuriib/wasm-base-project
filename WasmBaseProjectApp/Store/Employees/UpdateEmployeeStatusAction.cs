namespace WasmBaseProjectApp.Store.Employees;

public class UpdateEmployeeStatusAction
{
    public UpdateEmployeeStatusAction(int id, bool currentStatus)
    {
        Id = id;
        CurrentStatus = currentStatus;
    }

    public int Id { get; }
    public bool CurrentStatus { get; }
}

public class UpdateEmployeeStatusSuccessAction
{
    public UpdateEmployeeStatusSuccessAction(int id)
    {
        Id = id;
    }

    public int Id { get;  } 
}

public class UpdateEmployeeStatusFailedAction
{
    public UpdateEmployeeStatusFailedAction(string? errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    public string? ErrorMessage { get; }
}