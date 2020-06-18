using System.Security.Claims;

namespace Inori.User
{
    /// <summary>
    /// https://www.hanselman.com/blog/SystemThreadingThreadCurrentPrincipalVsSystemWebHttpContextCurrentUserOrWhyFormsAuthenticationCanBeSubtle.aspx
    /// https://davidpine.net/blog/principal-architecture-changes/
    /// </summary>
    public class CurrentUser : ICurrentUser
    {
        private readonly ICurrentPrincipalAccessor _currentPrincipalAccessor;
        public CurrentUser(ICurrentPrincipalAccessor currentPrincipalAccessor)
        {
            this._currentPrincipalAccessor = currentPrincipalAccessor;

            var email = _currentPrincipalAccessor.Principal?.FindFirst(ClaimTypes.Email);
            var clientIdClaim = _currentPrincipalAccessor.Principal?.FindFirst(ClaimTypes.Name);
        }

        public bool IsAuthenticated => throw new System.NotImplementedException();

        public int? Id => throw new System.NotImplementedException();

        public string UserName => throw new System.NotImplementedException();

        public string Email { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public string[] Roles => throw new System.NotImplementedException();

        public Claim[] FindClaims(string claim)
        {
            throw new System.NotImplementedException();
        }

        public Claim[] GetAllClaims()
        {
            throw new System.NotImplementedException();
        }

        public bool IsInRole(string Name)
        {
            throw new System.NotImplementedException();
        }
    }
}