using IdentityManager.Application.DTOs;
using IdentityManager.Application.Interfaces;
using IdentityManager.Domain.Entities;
using IdentityManager.Domain.Repositories;

namespace IdentityManager.Application.UseCases.Employees;

public class EmployeeUseCase : IEmployeeUseCase
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IPositionHistoryRepository _positionHistoryRepository;
    public EmployeeUseCase(IEmployeeRepository employeeRepository, IPositionHistoryRepository positionHistoryRepository)
    {
        _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        _positionHistoryRepository = positionHistoryRepository ?? throw new ArgumentNullException(nameof(positionHistoryRepository));
    }

    /// <summary>
    /// Adds a new employee to the system. 
    /// </summary>
    /// <param name="employeeDto"></param>
    public void AddEmployee(EmployeeDto employeeDto)
    {
        var employee = new Employee
        {
            Name = employeeDto.Name,
            CurrentPosition = employeeDto.CurrentPosition,
            Salary = employeeDto.Salary
        };

        _employeeRepository.AddEmployee(employee);
    }

    /// <summary>
    /// Deletes an employee by their ID.
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="ArgumentException"></exception>
    public void DeleteEmployee(int id)
    {
        var employee = _employeeRepository.GetEmployeeById(id);
        if (employee.Equals(default(Employee))) throw new ArgumentException($"Employee with ID {id} does not exist.");

        _employeeRepository.DeleteEmployee(id);
    }

    /// <summary>
    /// Retrieves all employees from the system.
    /// </summary>
    /// <returns>Return all of the employees of the system.</returns>
    public IEnumerable<EmployeeDto> GetAllEmployees()
    {
        var employees = _employeeRepository.GetAllEmployees();
        return employees.Select(e => new EmployeeDto
        {
            Id = e.Id,
            Name = e.Name,
            Salary = e.Salary,
            CurrentPosition = e.CurrentPosition
        });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">The employee does not exist.</exception>
    public EmployeeDto GetEmployeeById(int id)
    {
        var employee = _employeeRepository.GetEmployeeById(id);
        if (employee.Equals(default(Employee))) throw new ArgumentException($"Employee with ID {id} does not exist.");

        return new EmployeeDto
        {
            Id = employee.Id,
            Name = employee.Name,
            Salary = employee.Salary,
            CurrentPosition = employee.CurrentPosition
        };
    }

    /// <summary>
    /// Retrieves the position history of an employee by their ID.
    /// </summary>
    /// <param name="employeeId"></param>
    /// <returns>Return the employee's history position.</returns>
    /// <exception cref="ArgumentException">When the position is not found.</exception>
    public IEnumerable<PositionHistoryDto> GetPositionHistory(int employeeId)
    {
        var positionHistory = _positionHistoryRepository.GetPositionHistory(employeeId);

        if (positionHistory == null || !positionHistory.Any())
            throw new ArgumentException($"No position history found for employee with ID {employeeId}.");
        return positionHistory.Select(ph => new PositionHistoryDto
        {
            Id = ph.Id,
            EmployeeId = ph.EmployeeId,
            Position = ph.Position,
            StartDate = ph.StartDate,
            EndDate = ph.EndDate
        });
    }

    /// <summary>
    /// Updates an existing employee's details.
    /// </summary>
    /// <param name="employeeDto"></param>
    /// <exception cref="ArgumentException">The employee does not exist.</exception>
    public void UpdateEmployee(EmployeeDto employeeDto)
    {
        var employee = _employeeRepository.GetEmployeeById(employeeDto.Id);

        if (employee.Equals(default(Employee))) throw new ArgumentException($"Employee with ID {employeeDto.Id} does not exist.");

        employee.Name = employeeDto.Name;
        employee.CurrentPosition = employeeDto.CurrentPosition;
        employee.Salary = employeeDto.Salary;

        _employeeRepository.UpdateEmployee(employee);

    }
}
