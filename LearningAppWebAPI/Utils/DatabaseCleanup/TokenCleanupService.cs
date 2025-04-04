using LearningAppWebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Utils.DatabaseCleanup;

/// <summary>
/// 
/// </summary>
/// <param name="context"></param>
public class TokenCleanupService(AppDbContext context) : ITokenCleanupService
{
    /// <summary>
    /// 
    /// </summary>
    public async Task ClearRevokedTokensAsync()
    {
        var cutoffTime = DateTime.UtcNow;
        var revokedTokens = await context.RefreshToken
            .Where(t => t.IsRevoked || t.ExpiryDate < cutoffTime)
            .ToListAsync();

        context.RefreshToken.RemoveRange(revokedTokens);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    public async Task ClearAccessTokensAsync()
    {
        var cutoffTime = DateTime.UtcNow;
        var revokedTokens = await context.BlacklistedAccessTokens
            .Where(t => t.ExpiryDate < cutoffTime)
            .ToListAsync();

        context.BlacklistedAccessTokens.RemoveRange(revokedTokens);
        await context.SaveChangesAsync();
    }
}