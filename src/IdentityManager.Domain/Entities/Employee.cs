

namespace IdentityManager.Domain.Entities;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CurrentPosition { get; set; }
    public decimal Salary { get; set; }

    /// <summary>
    /// Calculates the yearly bonus based on the employee's current position and salary.
    /// </summary>
    /// <returns></returns>
    public decimal CalculateYearlyBonus()
    {
        var positionBonusRates = new Dictionary<int, decimal>()
        {
            {1, 0.20m },
            {2, 0.15m },
            {3, 0.12m },
            {4, 0.10m }
        };

        decimal defaultBonusRate = 0.10m;

        decimal bonusRate = positionBonusRates.ContainsKey(CurrentPosition)
            ? positionBonusRates[CurrentPosition]
            : defaultBonusRate;

        return Salary * bonusRate;

    }
}
