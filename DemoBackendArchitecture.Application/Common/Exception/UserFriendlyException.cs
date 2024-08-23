using DemoBackendArchitecture.Domain.Enums;

namespace DemoBackendArchitecture.Application.Common.Exception;

public class UserFriendlyException : System.Exception
{
    public string UserFriendlyMessage { get; set; }
    public ErrorCode ErrorCode { get; set; }
    
    public UserFriendlyException(ErrorCode errorCode, string userFriendlyMessage, System.Exception? innerException = null) : base(userFriendlyMessage, innerException)
    {
        ErrorCode = errorCode;
        UserFriendlyMessage = userFriendlyMessage;
    }
    
    public UserFriendlyException(string message, string userFriendlyMessage, System.Exception? innerException = null) : base(message, innerException)
    {
        UserFriendlyMessage = userFriendlyMessage;
    }
    
    public UserFriendlyException(ErrorCode errorCode, string message, string userFriendlyMessage, System.Exception? innerException = null) : base(message, innerException)
    {
        ErrorCode = errorCode;
        UserFriendlyMessage = userFriendlyMessage;
    }
}