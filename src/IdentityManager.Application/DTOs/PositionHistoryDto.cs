namespace IdentityManager.Application.DTOs;

public class PositionHistoryDto
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public string Position { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
