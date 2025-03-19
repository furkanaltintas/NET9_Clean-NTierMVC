using AutoMapper;
using Business.Modules.Auths.Constants;
using Core.Extensions;
using Core.Utilities.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;
using System.Security.Claims;

namespace Business.Modules.Auths.Services;

public class AuthManager : BaseManager, IAuthService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public AuthManager(IRepository repository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(repository, mapper)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    // BCrypt
    public async Task<IDataResult<GetUserDto>> SignInAsync(GetUserLoginDto getUserLoginDto)
    {
        User user = await Repository.GetRepository<User>().GetAsync(
            predicate: u => u.Email == getUserLoginDto.Email);

        if (user == null)
            return new DataResult<GetUserDto>(ResultStatus.Error, AuthsMessages.InvalidEmailOrPassword);

        bool isPasswordValid = BCryptPasswordService.VerifyPassword(getUserLoginDto.Password, user.Password);

        if (!isPasswordValid)
            return new DataResult<GetUserDto>(ResultStatus.Error, AuthsMessages.InvalidEmailOrPassword);


        GetUserDto getUserDto = Mapper.Map<GetUserDto>(user);

        await SetAuthCookie(getUserDto, getUserLoginDto.IsRememberMe);
        return new DataResult<GetUserDto>(ResultStatus.Success, getUserDto);
    }


    public async Task SignOutAsync()
    {
        await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }


    private async Task SetAuthCookie(GetUserDto getUserDto, bool rememberMe)
    {
        // Claim listesi oluşturma
        List<Claim> claims = new();
        claims.AddNameIdentifier(getUserDto.Id.ToString());
        claims.AddGivenName(getUserDto.FirstName);
        claims.AddSurname(getUserDto.LastName);
        claims.AddEmail(getUserDto.Email);
        claims.AddName(getUserDto.UserName);

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30),
            IsPersistent = rememberMe
        };

        await _httpContextAccessor.HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);
    }
}
