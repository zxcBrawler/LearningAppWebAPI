using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Response;
using LearningAppWebAPI.Models.DTO.Simple;
using LearningAppWebAPI.Remote;
using LearningAppWebAPI.Security;
using LearningAppWebAPI.Utils;
using LearningAppWebAPI.Utils.CustomAttributes;
using Microsoft.IdentityModel.Tokens;

namespace LearningAppWebAPI.Domain.Service
{
    /// <summary>
    /// The authorization service class
    /// </summary>
    [ScopedService]
    public class AuthorizationService(UserRepository repository, ITokenService tokenService, IEmailSender emailSender)
    {
        
       /// <summary>
       /// 
       /// </summary>
       /// <param name="registerRequestDto"></param>
       /// <returns></returns>
       public async Task<DataState<string>> RegisterAsync(RegisterRequestDto registerRequestDto)
       {
           
           var existingUser = await repository.GetUserByEmailAsync(registerRequestDto.Email);
           if (existingUser != null)
               return DataState<string>.Failure("User already exists", StatusCodes.Status400BadRequest);
       
           var existingRole = await repository.GetByRoleIdAsync(1);
           var user = new User
           {
               Email = registerRequestDto.Email,
               PasswordHash = PasswordHasher.HashPassword(registerRequestDto.Password),
               Username = registerRequestDto.Username,
               RoleId = 1,
               Role = existingRole,
               RegistrationDate = DateTime.UtcNow
           };
           
           await repository.CreateAsync(user);
           emailSender.SendEmail(registerRequestDto.Email, registerRequestDto.Username, user.Id);
          
           return DataState<string>.Success("Registration successful", StatusCodes.Status200OK);
       }
       
       /// <summary>
       /// 
       /// </summary>
       /// <param name="loginRequestDto"></param>
       /// <returns></returns>
       public async Task<DataState<LoginResponse>> LoginAsync(LoginRequestDto loginRequestDto)
       {
           var user = await repository.GetUserByEmailAsync(loginRequestDto.Email);
           if (user == null)
               return DataState<LoginResponse>.Failure("User not found", StatusCodes.Status404NotFound);
           if (!user.IsRegistrationConfirmed)
            return DataState<LoginResponse>.Failure("Please confirm your email first", StatusCodes.Status400BadRequest);

           var result =  PasswordHasher.VerifyPassword(loginRequestDto.Password, user.PasswordHash);
           
           if (!result) return DataState<LoginResponse>.Failure("Invalid credentials", StatusCodes.Status400BadRequest);
           
           var claims = tokenService.WriteClaims(user);
           var accessToken = tokenService.GenerateAccessToken(claims);
           var refreshToken = tokenService.GenerateRefreshToken(claims);

           await tokenService.StoreRefreshTokenAsync(user.Id, refreshToken);
           return DataState<LoginResponse>.Success(new LoginResponse
           {
               AccessToken = accessToken.Token, 
               RefreshToken = refreshToken.Token,
               AccessTokenExpiryDate = accessToken.ExpiryDate,
               RefreshTokenExpiryDate = refreshToken.ExpiryDate
           }, StatusCodes.Status200OK);

       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="userId"></param>
       /// <param name="jti"></param>
       /// <returns></returns>
       public async Task<DataState<string>> LogoutAsync(long userId, string jti)
       {
           await tokenService.RevokeTokensFromUser(userId);
           await tokenService.BlacklistAccessToken(jti);
           return DataState<string>.Success("Logout successful", StatusCodes.Status200OK);
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="refreshTokenRequestDto"></param>
       /// <returns></returns>
       public async Task<DataState<TokenResponse>> RefreshToken(RefreshTokenRequestDto refreshTokenRequestDto)
       {
           try
           {
               var newTokens = await tokenService.RefreshTokensAsync(
                   refreshTokenRequestDto.OldAccessToken, 
                   refreshTokenRequestDto.RefreshToken);
        
               return DataState<TokenResponse>.Success(newTokens, StatusCodes.Status200OK);
           }
           catch (SecurityTokenException ex)
           {
               return DataState<TokenResponse>.Failure(ex.Message, StatusCodes.Status401Unauthorized);
           }
           catch (ArgumentException ex)
           {
               return DataState<TokenResponse>.Failure(ex.Message, StatusCodes.Status400BadRequest);
           }
           catch (Exception ex)
           {
               return DataState<TokenResponse>.Failure(ex.Message, StatusCodes.Status500InternalServerError);
           }
          
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="userId"></param>
       /// <returns></returns>
       public async Task<DataState<string>> ConfirmEmail(long userId)
       {
           var existingUser = await repository.GetByIdAsync(userId);
           if (existingUser == null)
               return DataState<string>.Failure("User not found", StatusCodes.Status404NotFound);
           existingUser.IsRegistrationConfirmed = true;
           await repository.UpdateAsync(userId, existingUser);
           return DataState<string>.Success("Email confirmation successful. You can now Log in into your account", StatusCodes.Status200OK);
       }
    }
}
