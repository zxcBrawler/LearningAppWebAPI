using Coravel.Invocable;

namespace LearningAppWebAPI.Utils.Job;

/// <summary>
/// 
/// </summary>
/// <param name="cleanupService"></param>
/// <param name="logger"></param>
public class TokenCleanupJob(ITokenCleanupService cleanupService, ILogger<TokenCleanupJob> logger) : IInvocable
{
    /// <summary>
    /// 
    /// </summary>
    public async Task Invoke()
    {
        logger.LogInformation("Scheduled token cleanup job started (runs every 10 minutes).");
        await cleanupService.ClearRevokedTokensAsync();
        await cleanupService.ClearAccessTokensAsync();
        logger.LogInformation("Scheduled token cleanup job finished (runs every 10 minutes).");
    }
}