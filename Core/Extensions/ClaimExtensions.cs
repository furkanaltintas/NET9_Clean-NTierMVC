using System.Security.Claims;

namespace Core.Extensions;

public static class ClaimExtensions
{
    public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
    {
        claims.Add(new Claim(
            type: ClaimTypes.NameIdentifier,
            value: nameIdentifier));
    }

    public static void AddGivenName(this ICollection<Claim> claims, string firstName)
    {
        claims.Add(new Claim(
            type: ClaimTypes.GivenName,
            value: firstName));
    }

    public static void AddSurname(this ICollection<Claim> claims, string surname)
    {
        claims.Add(new Claim(
            type: ClaimTypes.Surname,
            value: surname));
    }

    public static void AddEmail(this ICollection<Claim> claims, string email)
    {
        claims.Add(new Claim(
            type: ClaimTypes.Email,
            value: email));
    }

    public static void AddName(this ICollection<Claim> claims, string name)
    {
        claims.Add(new Claim(
            type: ClaimTypes.Name,
            value: name));
    }

    public static void AddRoles(this ICollection<Claim> claims, string[] roles)
    {
        roles
            .ToList()
            .ForEach(role => claims.Add
            (new Claim(type: ClaimTypes.Role, value: role)));
    }
}