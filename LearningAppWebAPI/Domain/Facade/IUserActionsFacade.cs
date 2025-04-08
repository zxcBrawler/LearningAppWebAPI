using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models.DTO.Complex;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Response;
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
    Task<DataState<UserSimpleDto>> GetUserProfileAsync(long userId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<DataState<List<DictionarySimpleDto>>> GetUserDictionaries(long userId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<DataState<List<UserCourseSimpleDto>>> GetUserCourses(long userId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="dictionaryId"></param>
    /// <returns></returns>
    Task<DataState<DictionarySimpleDto>> GetUserDictionaryById(int dictionaryId, long userId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="addDictionaryRequestDto"></param>
    /// <returns></returns>
    Task<DataState<DictionarySimpleDto>> AddNewDictionary(long userId, AddDictionaryRequestDto addDictionaryRequestDto);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="dictionaryId"></param>
    /// <param name="updateDictionaryRequestDto"></param>
    /// <returns></returns>
    Task<DataState<bool>> UpdateDictionary(long userId, int dictionaryId, UpdateDictionaryRequestDto updateDictionaryRequestDto);

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
    Task<DataState<bool>> UpdateUserPassword(long userId, UpdatePasswordRequestDto updatePasswordRequestDto);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="updateProfileRequestDto"></param>
    /// <returns></returns>
    Task<DataState<bool>> UpdateUserProfile(long userId, UpdateProfileRequestDto updateProfileRequestDto);
    
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="courseId"></param>
    /// <returns></returns>
    Task<DataState<UserCourseSimpleDto>> StartNewCourse(long userId, long courseId);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="dictionaryId"></param>
    /// <param name="wordId"></param>
    /// <returns></returns>
    Task<DataState<DictionarySimpleDto>> AddWordToDictionary(long userId, int dictionaryId, int wordId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="refreshTokenRequestDto"></param>
    /// <returns></returns>
    Task<DataState<LoginResponse>> UpdateAllTokens(RefreshTokenRequestDto refreshTokenRequestDto);
    
    
   
}