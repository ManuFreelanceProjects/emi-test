using IdentityManager.Domain.Entities;
using IdentityManager.Domain.Repositories;

namespace IdentityManager.Domain.Services;

public class InMemoryEmployeeRepository : IEmployeeRepository
{
    private readonly List<Employee> _employees = new List<Employee>();

    public void AddEmployee(Employee employee)
    {
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee), "Employee cannot be null");
        }

        if (_employees.Any(e => e.Id == employee.Id))
        {
            throw new InvalidOperationException($"Employee with ID {employee.Id} already exists.");
        }

        if (employee.Id == 0)
        {
            employee.Id = 1; // Simple ID generation
        }

        _employees.Add(employee);
        
    }

    public void DeleteEmployee(int id)
    {
        var employee = _employees.FirstOrDefault(e => e.Id == id);
        if (employee == null)
        {
            throw new KeyNotFoundException($"Employee with ID {id} not found.");
        }
        _employees.Remove(employee);
    }

    public IEnumerable<Employee> GetAllEmployees()
    {
        return _employees;
    }

    public Employee GetEmployeeById(int id)
    {
        var employee = _employees.FirstOrDefault(e => e.Id == id);
        if (employee == null)
        {
            throw new KeyNotFoundException($"Employee with ID {id} not found.");
        }
        return employee;
        
    }

    public void UpdateEmployee(Employee employee)
    {
        var existingEmployee = _employees.FirstOrDefault(e => e.Id == employee.Id);
        if (existingEmployee == null)
        {
            throw new KeyNotFoundException($"Employee with ID {employee.Id} not found.");
        }

        existingEmployee.Name = employee.Name;
        existingEmployee.CurrentPosition = employee.CurrentPosition;
        existingEmployee.Salary = employee.Salary;

    }
}
