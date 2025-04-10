using FluentValidation;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Utils.CustomAttributes;

namespace LearningAppWebAPI.Models.DTO.Validator;


/// <summary>
/// 
/// </summary>
[ScopedService]
public class LogInRequestValidator : AbstractValidator<LoginRequestDto>
{
    /// <summary>
    /// 
    /// </summary>
    public LogInRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8).WithMessage("Password is required. Minimum 8 characters");
    }
}