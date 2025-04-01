using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Utils;
using LearningAppWebAPI.Utils.CustomAttributes;
using LoginRequest = LearningAppWebAPI.Models.DTO.Request.LoginRequest;
using RegisterRequest = LearningAppWebAPI.Models.DTO.Request.RegisterRequest;

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
       /// <param name="registerRequest"></param>
       /// <returns></returns>
       public async Task<DataState<string>> RegisterAsync(RegisterRequest registerRequest)
       {
           
           var existingUser = await repository.GetUserByEmailAsync(registerRequest.Email);
           if (existingUser != null)
               return DataState<string>.Failure("User already exists", StatusCodes.Status400BadRequest);
       
           var existingRole = await repository.GetByRoleIdAsync(1);
           var user = new User
           {
               Email = registerRequest.Email,
               PasswordHash = PasswordHasher.HashPassword(registerRequest.Password),
               Username = registerRequest.Username,
               RoleId = 1,
               Role = existingRole
           };
           
           var newUser = await repository.CreateAsync(user);
          
           return DataState<string>.Success("Registration successful", StatusCodes.Status200OK);
       }
       
       /// <summary>
       /// 
       /// </summary>
       /// <param name="loginRequest"></param>
       /// <returns></returns>
       public async Task<DataState<User?>> LoginAsync(LoginRequest loginRequest)
       {
           var user = await repository.GetUserByEmailAsync(loginRequest.Email);
           if (user == null)
               return DataState<User?>.Failure("User not found", StatusCodes.Status404NotFound);

           var result =  user.PasswordHash != null && PasswordHasher.VerifyPassword(loginRequest.Password, user.PasswordHash);
            
           return !result ? DataState<User?>.Failure("Invalid sign in credentials", StatusCodes.Status400BadRequest) : DataState<User?>.Success(user, StatusCodes.Status200OK);
       }
    }
}
