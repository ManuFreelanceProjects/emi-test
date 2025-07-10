using IdentityManager.Application.DTOs;

namespace IdentityManager.Application.Interfaces;

public interface IEmployeeUseCase
{
    IEnumerable<EmployeeDto> GetAllEmployees();
    EmployeeDto GetEmployeeById(int id);
    void AddEmployee(EmployeeDto employee);
    void UpdateEmployee(EmployeeDto employee);
    void DeleteEmployee(int id);
    IEnumerable<PositionHistoryDto> GetPositionHistory(int empliyeeId);

}
