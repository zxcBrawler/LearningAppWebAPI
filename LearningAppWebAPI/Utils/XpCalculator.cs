using LearningAppWebAPI.Models;

namespace LearningAppWebAPI.Utils;

/// <summary>
/// 
/// </summary>
public static class XpCalculator
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="totalXp"></param>
    /// <param name="userLifeCount"></param>
    /// <returns></returns>
    public static int CalculateXp(int totalXp, int userLifeCount)
    {
        var penalty = GetPenaltyPercentage(userLifeCount);
        var finalXp = totalXp * (100 - penalty) / 100;
        return finalXp;
    }

    private static int GetPenaltyPercentage(int userLifeCount)
    {
        return userLifeCount switch
        {
            3 => 0,
            2 => 10,
            1 => 20,
            _ => throw new ArgumentOutOfRangeException(nameof(userLifeCount))
        };
    }
}