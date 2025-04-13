using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Service;
using LearningAppWebAPI.Domain.Service.Impl;
using LearningAppWebAPI.Domain.Service.Interface;
using LearningAppWebAPI.Models.DTO.Complex;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Response;
using LearningAppWebAPI.Models.DTO.Simple;
using LearningAppWebAPI.Security;

namespace LearningAppWebAPI.Domain.Facade;

/// <summary>
/// 
/// </summary>
/// <param name="userService"></param>
/// <param name="userCourseService"></param>
/// <param name="dictionaryService"></param>
public class UserActionsFacadeImpl(IUserService userService, IUserCourseService userCourseService, IDictionaryService dictionaryService, ITokenService tokenService) : IUserActionsFacade
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<DataState<UserSimpleDto>> GetUserProfileAsync(long userId)
    {
        return await userService.GetUserByIdAsync(userId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<DataState<List<DictionarySimpleDto>>> GetUserDictionaries(long userId)
    {
        return await dictionaryService.GetAllByUserIdAsync(userId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<DataState<List<UserCourseSimpleDto>>> GetUserCourses(long userId)
    {
        return await userCourseService.GetByAllByUserId(userId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="courseId"></param>
    /// <returns></returns>
    public async Task<DataState<UserCourseSimpleDto>> GetUserCourse(long userId, long courseId)
    {
        return await userCourseService.GetByCourseIdAndUserId(userId, courseId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<DataState<List<CourseComplexDto>>> GetOtherCourses(long userId)
    {
        return await userCourseService.GetOtherCourses(userId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dictionaryId"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<DataState<DictionarySimpleDto>> GetUserDictionaryById(int dictionaryId, long userId)
    {
        return await dictionaryService.GetUserDictionaryById(dictionaryId, userId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="addDictionaryRequestDto"></param>
    /// <returns></returns>
    public async Task<DataState<DictionarySimpleDto>> AddNewDictionary(long userId, AddDictionaryRequestDto addDictionaryRequestDto)
    {
        return await dictionaryService.AddNewDictionary(userId, addDictionaryRequestDto);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="dictionaryId"></param>
    /// <param name="updateDictionaryRequestDto"></param>
    /// <returns></returns>
    public async Task<DataState<bool>> UpdateDictionary(long userId, int dictionaryId, UpdateDictionaryRequestDto updateDictionaryRequestDto)
    {
        return await dictionaryService.UpdateDictionary(userId, dictionaryId, updateDictionaryRequestDto);
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
    public async Task<DataState<bool>> UpdateUserPassword(long userId, UpdatePasswordRequestDto updatePasswordRequestDto)
    {
        return  await userService.UpdateUserPassword(userId, updatePasswordRequestDto);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="updatePasswordRequestDto"></param>
    /// <returns></returns>
    public async Task<DataState<bool>> UpdateUserProfile(long userId, UpdateProfileRequestDto updatePasswordRequestDto)
    {
        return await userService.UpdateUserProfile(userId, updatePasswordRequestDto);
    }
    
    

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="courseId"></param>
    /// <returns></returns>
    public async Task<DataState<UserCourseSimpleDto>> StartNewCourse(long userId, long courseId)
    {
        return await userCourseService.StartNewCourse(userId, courseId);
    }

    public async Task<DataState<UserCourseSimpleDto>> CompleteLesson(long userId, long courseId)
    {
        return await userCourseService.CompleteLesson(userId, courseId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="dictionaryId"></param>
    /// <param name="wordId"></param>
    /// <returns></returns>
    public async Task<DataState<DictionarySimpleDto>> AddWordToDictionary(long userId, int dictionaryId, int wordId)
    {
        return await dictionaryService.AddWordToDictionary(userId, dictionaryId, wordId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="refreshTokenRequestDto"></param>
    /// <returns></returns>
    public async Task<DataState<LoginResponse>> UpdateAllTokens(RefreshTokenRequestDto refreshTokenRequestDto)
    {
        var response = await tokenService.UpdateAllTokens(refreshTokenRequestDto.OldAccessToken, refreshTokenRequestDto.RefreshToken);
        return DataState<LoginResponse>.Success(response, StatusCodes.Status200OK);
    }
}