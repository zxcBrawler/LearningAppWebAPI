using LearningAppWebAPI.Controllers;
using LearningAppWebAPI.Domain.Service;
using LearningAppWebAPI.Utils;

namespace LearningAppWebAPI.Domain.Facade;

/// <summary>
/// 
/// </summary>
/// <param name="userService"></param>
/// <param name="userCourseService"></param>
/// <param name="dictionaryService"></param>
public abstract class UserActionsFacade(UserService userService, UserCourseService userCourseService, DictionaryService dictionaryService) 
{
   
}