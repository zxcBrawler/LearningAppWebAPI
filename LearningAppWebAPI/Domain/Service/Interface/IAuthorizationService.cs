using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Response;
using LearningAppWebAPI.Utils.CustomAttributes;

namespace LearningAppWebAPI.Domain.Service.Interface;

public interface IAuthorizationService
{
    Task<DataState<string>> RegisterAsync(RegisterRequestDto registerRequestDto);
    Task<DataState<LoginResponse>> LoginAsync(LoginRequestDto loginRequestDto);
    Task<DataState<string>> LogoutAsync(long userId, string jti);
    Task<DataState<TokenResponse>> RefreshToken(RefreshTokenRequestDto refreshTokenRequestDto);
    Task<DataState<string>> ConfirmEmail(long userId);
}