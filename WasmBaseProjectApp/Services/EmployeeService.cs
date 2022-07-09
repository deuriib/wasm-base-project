using System.Net.Http.Json;
using Bogus;
using System.Linq;

namespace WasmBaseProjectApp.Services
{

    public class EmployeeService
    {
        private readonly HttpClient _httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            Randomizer.Seed = new Random(100);
        }

        public async Task<Employee[]> GetEmployeesAsync()
        {
            //var employees = await _httpClient.GetFromJsonAsync<Employee[]>("api/employees");
            var employees = await GenerateFakeEmployees();
            return employees;
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            //var employee = await _httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");
            var employees = await GenerateFakeEmployees();
                var employee = employees.SingleOrDefault(e => e.Id.Equals(id));
            return employee ?? new ();
        }

        public async Task AddEmployeeAsync(Employee request)
        {
            await _httpClient.PostAsJsonAsync("api/employees", request);
        }

        public async Task UpdateEmployeeAsync(int id, Employee request)
        {
            await _httpClient.PostAsJsonAsync($"api/employees/{id}", request);
        }

        private Task<Employee[]> GenerateFakeEmployees()
        {
            var employeeId = 1;
            var fakeEmployees = new Faker<Employee>()
                .StrictMode(true)
                .RuleFor(e => e.Id, f => employeeId++)
                .RuleFor(e => e.Name, f => f.Person.FirstName)
                .RuleFor(e => e.LasName, f => f.Person.LastName)
                .RuleFor(e => e.Address, f => $"{f.Person.Address.City}{f.Person.Address.State}")
                .RuleFor(e => e.Status, f => f.Random.Bool())
                .RuleFor(e => e.Note, f => f.Random.String())
                .RuleFor(e => e.YearOfBirth, f => f.Person.DateOfBirth.Year)
                .RuleFor(e => e.DayOfBirth, f => f.Person.DateOfBirth.Day)
                .RuleFor(e => e.MonthOfBirth, f => f.Person.DateOfBirth.Month)
                .RuleFor(e => e.CreateDate, f => f.Date.Past());

            return Task.FromResult(fakeEmployees.Generate(50).ToArray());
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
        public int YearOfBirth { get; set; }
        public int DayOfBirth { get; set; }
        public int MonthOfBirth { get; set; }
        public DateTime CreateDate { get; set; }
    }
}

