using IdentityManager.Domain.Entities;

namespace IdentityManager.Domain.Repositories;

public interface IPositionHistoryRepository
{
    IEnumerable<PositionHistory> GetPositionHistory(int employeeId);
}
