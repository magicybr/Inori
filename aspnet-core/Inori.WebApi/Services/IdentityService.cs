using System;
using Microsoft.AspNetCore.Http;

namespace Inori.WebApi.Services
{
    /// <summary>
    /// https://www.hanselman.com/blog/SystemThreadingThreadCurrentPrincipalVsSystemWebHttpContextCurrentUserOrWhyFormsAuthenticationCanBeSubtle.aspx
    /// https://davidpine.net/blog/principal-architecture-changes/
    /// </summary>
    public class IdentityService : IIdentityService
    {
        private IHttpContextAccessor _context;

        public IdentityService(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public string GetUserIdentity()
        {
            throw new System.NotImplementedException();
        }
        public string GetUserName()
        {
            throw new System.NotImplementedException();
        }
    }
}