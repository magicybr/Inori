using System.Security.Claims;
using System.Security.Principal;

namespace Inori.User
{
    public class ThreadCurrentPrincipalAccessor : ICurrentPrincipalAccessor
    {
        private readonly IPrincipal _principal;
        public ThreadCurrentPrincipalAccessor(IPrincipal principal)
        {
            this._principal = principal;
        }
        public ClaimsPrincipal Principal => this._principal as ClaimsPrincipal;
    }
}
