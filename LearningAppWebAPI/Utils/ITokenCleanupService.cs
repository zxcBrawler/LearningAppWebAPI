namespace LearningAppWebAPI.Utils;

/// <summary>
/// 
/// </summary>
public interface ITokenCleanupService
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task ClearRevokedTokensAsync();
    Task ClearAccessTokensAsync();
}