using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Service;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Domain.Facade;

/// <summary>
/// 
/// </summary>
/// <param name="userService"></param>
/// <param name="userCourseService"></param>
/// <param name="dictionaryService"></param>
public class UserActionsFacadeImpl(UserService userService, UserCourseService userCourseService, DictionaryService dictionaryService) : IUserActionsFacade
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<DataState<List<DictionarySimpleDto>>> GetUserDictionaries(int userId)
    {
        return await dictionaryService.GetAllByUserIdAsync(userId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<DataState<List<UserCourseSimpleDto>>> GetUserCourses(int userId)
    {
        return await userCourseService.GetByAllByUserId(userId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dictionaryId"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<DataState<DictionarySimpleDto>> GetUserDictionaryById(int dictionaryId, int userId)
    {
        return await dictionaryService.GetUserDictionaryById(dictionaryId, userId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="addDictionaryRequestDto"></param>
    /// <returns></returns>
    public async Task<DataState<DictionarySimpleDto>> AddNewDictionary(int userId, AddDictionaryRequestDto addDictionaryRequestDto)
    {
        return await dictionaryService.AddNewDictionary(userId, addDictionaryRequestDto);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dictionaryId"></param>
    /// <returns></returns>
    public async Task<DataState<bool>> DeleteDictionary(int dictionaryId)
    {
        return await dictionaryService.DeleteDictionaryAsync(dictionaryId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="updatePasswordRequestDto"></param>
    /// <returns></returns>
    public async Task<DataState<bool>> UpdateUserPassword(int userId, UpdatePasswordRequestDto updatePasswordRequestDto)
    {
        return  await userService.UpdateUserPassword(userId, updatePasswordRequestDto);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="updatePasswordRequestDto"></param>
    /// <returns></returns>
    public async Task<DataState<bool>> UpdateUserProfile(int userId, UpdateProfileRequestDto updatePasswordRequestDto)
    {
        return await userService.UpdateUserProfile(userId, updatePasswordRequestDto);
    }
}