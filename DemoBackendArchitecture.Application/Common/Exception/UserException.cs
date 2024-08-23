using DemoBackendArchitecture.Domain.Constants;
using DemoBackendArchitecture.Domain.Enums;

namespace DemoBackendArchitecture.Application.Common.Exception;

public abstract class UserException
{
    public static UserFriendlyException UserAlreadyExistsException(string field)
        => new(ErrorCode.BadRequest, string.Format(UserErrorMessage.AlreadyExists, field), string.Format(UserErrorMessage.AlreadyExists, field));
    
    public static UserFriendlyException UserUnauthorizedException()
        => new(ErrorCode.Unauthorized, UserErrorMessage.Unauthorized, UserErrorMessage.Unauthorized);
    
    public static UserFriendlyException InternalException(System.Exception? exception)
        => new(ErrorCode.Internal, ErrorMessage.Internal, ErrorMessage.Internal, exception);
    
    public static UserFriendlyException BadRequestException(string errorMessage)
        => new(ErrorCode.BadRequest, errorMessage, errorMessage);
    
}