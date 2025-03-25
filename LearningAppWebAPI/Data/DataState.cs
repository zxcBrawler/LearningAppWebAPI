namespace LearningAppWebAPI.Data;

#pragma warning disable CS1591

public class DataState<T>
{
    public bool IsSuccess { get; private set; }
    public T? Value { get; private set; }
    public string? ErrorMessage { get; private set; }
    public int StatusCode { get; private set; }

    public static DataState<T> Success(T value, int statusCode)
    {
        return new DataState<T> { IsSuccess = true, Value = value, StatusCode = statusCode };
    }
    public static DataState<T> Failure(string errorMessage, int statusCode)
    {
        return new DataState<T> { IsSuccess = false, ErrorMessage = errorMessage , StatusCode = statusCode };
    }
}
