using IdentityManager.Domain.Entities;
using IdentityManager.Domain.Repositories;

namespace IdentityManager.Domain.Services;

public class InMemoryPositionHistoryRepository : IPositionHistoryRepository
{
    private readonly List<PositionHistory> _positionHistories = new List<PositionHistory>();
    public IEnumerable<PositionHistory> GetPositionHistory(int employeeId)
    {
        return _positionHistories.Where(ph => ph.EmployeeId == employeeId);
    }
}
