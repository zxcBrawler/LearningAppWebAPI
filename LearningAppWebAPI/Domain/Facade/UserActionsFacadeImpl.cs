using LearningAppWebAPI.Domain.Service;
using LearningAppWebAPI.Utils;

namespace LearningAppWebAPI.Domain.Facade;

public class UserActionsFacadeImpl(UserService userService, UserCourseService userCourseService, DictionaryService dictionaryService) : UserActionsFacade(userService, userCourseService, dictionaryService)
{
    
}