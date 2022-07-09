using System.Net.Http.Json;

namespace WasmBaseProjectApp.Services
{

    public class EmployeeService
    {
        private readonly HttpClient _httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Employee[]> GetEmployeesAsync()
        {
            var employees = await _httpClient.GetFromJsonAsync<Employee[]>("api/employees");
            return employees ?? Array.Empty<Employee>();
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            var employee = await _httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");
            return employee ?? new();
        }

        public async Task AddEmployeeAsync(Employee request)
        {
            await _httpClient.PostAsJsonAsync("api/employees", request);
        }

        public async Task UpdateEmployeeAsync(int id, Employee request)
        {
            await _httpClient.PostAsJsonAsync($"api/employees/{id}", request);
        }
    }


    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LasName { get; set; }
        public string? Address { get; set; }
        public bool Status { get; set; }
        public string? Note { get; set; }
        public int YearOfbirth { get; set; }
        public int DayOfbirth { get; set; }
        public int MonthOfbirth { get; set; }
        public DateTime CreateDate { get; set; }
    }
}

