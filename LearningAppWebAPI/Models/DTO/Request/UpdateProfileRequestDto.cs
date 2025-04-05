﻿namespace LearningAppWebAPI.Models.DTO.Request;

public class UpdateProfileRequestDto
{
    public required string Username { get; set; }
   
    public required string ProfilePicture { get; init; }
    public required string Email { get; set; }
}