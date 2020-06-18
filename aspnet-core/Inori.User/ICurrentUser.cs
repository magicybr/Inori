using JetBrains.Annotations;
using System.Security.Claims;

namespace Inori.User
{
    public interface ICurrentUser
    {
        bool IsAuthenticated { get; }

        // 用户ID
        [CanBeNull]
        int? Id { get; }

        // 用户名
        [CanBeNull]
        string UserName { get; }

        // 电子邮件
        [CanBeNull]
        string Email { get; set; }

        [NotNull]
        string[] Roles { get; }

        Claim[] FindClaims(string claim);

        Claim[] GetAllClaims();

        bool IsInRole(string Name);
    }
}