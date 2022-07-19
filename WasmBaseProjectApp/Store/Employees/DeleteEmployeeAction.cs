namespace WasmBaseProjectApp.Store.Employees;

public class DeleteEmployeeAction
{
    public DeleteEmployeeAction(int id)
    {
        Id = id;
    }

    public int Id { get;  } 
}

public class DeleteEmployeeSuccessAction
{
    public DeleteEmployeeSuccessAction(int id)
    {
        Id = id;
    }

    public int Id { get;  }
}

public class DeleteEmployeeFailedAction
{
    public DeleteEmployeeFailedAction(string? errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    public string? ErrorMessage { get;  } 
}