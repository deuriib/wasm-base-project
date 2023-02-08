using WasmBaseProject.Domain.Enums;

namespace WasmBaseProject.Domain.Models;

public class Employee
{
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set;}
    public string Email { get; private set;}
    public string? Address { get; private set; }
    public string? Note { get; private set; }
    public DateTime Birthdate { get; private set; }
    public EmployeeStatus Status { get; private set; }

     public Employee(int id,string firstName, string lastName, string email, DateTime birthdate)
     {
         Id = id;
         FirstName = firstName;
         LastName = lastName;
         Email = email;
         Birthdate = birthdate;
         Address = null;
         Note = null;
         Status = EmployeeStatus.Active;
     }

     public void ChangeName(string firstName, string lastName)
     {
         FirstName = firstName;
         LastName = lastName;
     }

     public void UpdateBirthDate(DateTime birthdate)
     {
         if (birthdate.Year > DateTime.Now.AddYears(-18).Year)
             throw new ArgumentException($"{nameof(birthdate)} must be greater than 18 years old.");

         Birthdate = birthdate;
     }

     public void AddOrUpdateAddress(string? address)
     {
         Address = address;
     }

     public void AddOrUpdateNote(string? note)
     {
         Note = note;
     }

     public void SetStatus(EmployeeStatus status) => Status = status;
}