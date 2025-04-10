using FluentValidation;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Utils.CustomAttributes;

namespace LearningAppWebAPI.Models.DTO.Validator;

/// <summary>
/// 
/// </summary>
[ScopedService]
public class RegisterRequestValidator : AbstractValidator<RegisterRequestDto>
{
    /// <summary>
    /// 
    /// </summary>
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8).WithMessage("Password is required");
        RuleFor(x => x.Username).NotEmpty().MinimumLength(3).WithMessage("Username is required");
    }
}