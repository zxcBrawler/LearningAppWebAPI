using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Domain.Facade;

/// <summary>
/// 
/// </summary>
/// <param name="userService"></param>
/// <param name="userCourseService"></param>
/// <param name="dictionaryService"></param>
public interface IUserActionsFacade
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<DataState<List<DictionarySimpleDto>>> GetUserDictionaries(int userId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<DataState<List<UserCourseSimpleDto>>> GetUserCourses(int userId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="dictionaryId"></param>
    /// <returns></returns>
    Task<DataState<DictionarySimpleDto>> GetUserDictionaryById(int dictionaryId, int userId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="addDictionaryRequestDto"></param>
    /// <returns></returns>
    Task<DataState<DictionarySimpleDto>> AddNewDictionary(int userId, AddDictionaryRequestDto addDictionaryRequestDto);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dictionaryId"></param>
    /// <returns></returns>
    Task<DataState<bool>> DeleteDictionary(int dictionaryId);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="updatePasswordRequestDto"></param>
    /// <returns></returns>
    Task<DataState<bool>> UpdateUserPassword(int userId, UpdatePasswordRequestDto updatePasswordRequestDto);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="updateProfileRequestDto"></param>
    /// <returns></returns>
    Task<DataState<bool>> UpdateUserProfile(int userId, UpdateProfileRequestDto updateProfileRequestDto);
    
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="courseId"></param>
    /// <returns></returns>
    Task<DataState<UserCourseSimpleDto>> StartNewCourse(int userId, int courseId);
   
}