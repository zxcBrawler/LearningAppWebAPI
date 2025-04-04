using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Utils;
using LearningAppWebAPI.Utils.CustomAttributes;

namespace LearningAppWebAPI.Domain.Service
{
    /// <summary>
    /// The authorization service class
    /// </summary>
    [ScopedService]
    public class AuthorizationService(UserRepository repository)
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
               Role = existingRole
           };
           
           var newUser = await repository.CreateAsync(user);
          
           return DataState<string>.Success("Registration successful", StatusCodes.Status200OK);
       }
       
       /// <summary>
       /// 
       /// </summary>
       /// <param name="loginRequestDto"></param>
       /// <returns></returns>
       public async Task<DataState<User>> LoginAsync(LoginRequestDto loginRequestDto)
       {
           var user = await repository.GetUserByEmailAsync(loginRequestDto.Email);
           if (user == null)
               return DataState<User>.Failure("User not found", StatusCodes.Status404NotFound);

           var result =  user.PasswordHash != null && PasswordHasher.VerifyPassword(loginRequestDto.Password, user.PasswordHash);
            
           return !result ? DataState<User>.Failure("Invalid sign in credentials", StatusCodes.Status400BadRequest) : 
               DataState<User>.Success(user, StatusCodes.Status200OK);
       }
    }
}
