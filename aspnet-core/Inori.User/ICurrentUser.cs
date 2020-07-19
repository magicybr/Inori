using JetBrains.Annotations;
using System.Security.Claims;

namespace Inori.User
{
    public interface ICurrentUser
    {
        bool IsAuthenticated { get; }

        [CanBeNull]
        int? Id { get; }

        [CanBeNull]
        string UserName { get; }

        [CanBeNull]
        string Email { get; set; }

        [NotNull]
        string[] Roles { get; }

        Claim[] FindClaims(string claim);

        Claim[] GetAllClaims();

        bool IsInRole(string Name);
    }
}