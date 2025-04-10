using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Domain.Service.Interface;

public interface IUserService
{
    Task<DataState<List<UserSimpleDto>>> GetAllUsersAsync();
    Task<DataState<UserSimpleDto>> GetUserByIdAsync(long id);
    Task<DataState<UserSimpleDto>> CreateUserAsync(AddUserRequestDto requestDto);
    Task<DataState<bool>> UpdateUserAsync(int id, AddUserRequestDto updateRequest);
    Task<DataState<bool>> DeleteUserAsync(int id);
    Task<DataState<bool>> UpdateUserProfile(long userId, UpdateProfileRequestDto updateProfileRequestDto);
    Task<DataState<bool>> UpdateUserPassword(long userId, UpdatePasswordRequestDto updatePasswordRequestDto);
}