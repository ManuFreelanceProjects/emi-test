using System.Linq.Expressions;
using IdentityManager.Application.DTOs;
using IdentityManager.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeUseCase _employeeUseCase;
    public EmployeeController(IEmployeeUseCase employeeUseCase)
    {
        _employeeUseCase = employeeUseCase;
    }

    [Authorize(Roles = "Admin,User")]
    [HttpGet]
    public ActionResult<IEnumerable<EmployeeDto>> GetAllEmployees()
    {
        var employees = _employeeUseCase.GetAllEmployees();
        return Ok(employees);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public ActionResult<EmployeeDto> getEmployeeById(int id)
    {
        try
        {
            var employee = _employeeUseCase.GetEmployeeById(id);
            return Ok(employee);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public ActionResult AddEmployee([FromBody] EmployeeDto employee)
    {
        try
        {
            _employeeUseCase.AddEmployee(employee);
            return CreatedAtAction(nameof(getEmployeeById), new { Id = employee.Id }, employee);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]
    public ActionResult UpdateEmployee([FromBody] EmployeeDto employee)
    {
        try
        {
            _employeeUseCase.UpdateEmployee(employee);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("id")]
    public ActionResult DeleteEmployee(int id)
    {
        try
        {
            _employeeUseCase.DeleteEmployee(id);
            return NoContent();

        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
