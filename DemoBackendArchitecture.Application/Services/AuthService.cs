using AutoMapper;
using DemoBackendArchitecture.Application.Common.Exception;
using DemoBackendArchitecture.Application.Common.Interfaces;
using DemoBackendArchitecture.Application.Common.Model.User;
using DemoBackendArchitecture.Application.Common.Utilities;
using DemoBackendArchitecture.Domain.Constants;
using DemoBackendArchitecture.Domain.Interfaces;

namespace DemoBackendArchitecture.Application.Services;

public class AuthService(IUserRepository userRepository, ITokenService tokenService, ICookieService cookieService, IMapper mapper) : IAuthService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ITokenService _tokenService = tokenService;
    private readonly ICookieService _cookieService = cookieService;
    private readonly IMapper _mapper = mapper;
    public async Task<UserSignInResponse> SignIn(UserSignInRequest request)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email)
            ?? throw UserException.BadRequestException(UserErrorMessage.UserNotExist);
        //using Identity to verify password
        if (StringHelper.Verify(user, request.Password!))
        {
            throw UserException.BadRequestException(UserErrorMessage.PasswordIncorrect);
        }
        
        //generate token
        var token = _tokenService.GenerateToken(user);
        //set token to cookie
        _cookieService.Set(token);
        
        //map user to response
        var response = _mapper.Map<UserSignInResponse>(user);
        //set token to response
        response.Token = token;
        //set user role to response
        response.Role = user.Role.RoleName;
        //return response
        return response;
    }
}