using IdentityManager.Domain.Entities;

namespace IdentityManager.Domain.Repositories;

public interface IEmployeeRepository
{
    IEnumerable<Employee> GetAllEmployees();
    Employee GetEmployeeById(int id);
    void AddEmployee(Employee employee);
    void UpdateEmployee(Employee employee);
    void DeleteEmployee(int id);
}
