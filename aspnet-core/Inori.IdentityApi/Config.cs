using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace Inori.IdentityApi
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIds()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>()
            {
                new ApiResource("api1","My Api #1")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client{
                    ClientId = "angular",
                    ClientName = "angular spa",
                    ClientUri = "http://localhost:4200",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = true,
                    AccessTokenLifetime = 60,
                    RedirectUris = {
                        "http://localhost:4200/signin-oidc",
                        "http://localhost:4200/redirect-silent-renew"
                    },
                    PostLogoutRedirectUris = {
                        "http://localhost:4200"
                    },
                    AllowedCorsOrigins = {
                        "http://localhost:4200"
                    },
                    AllowedScopes = {
                        OidcConstants.StandardScopes.OpenId,
                        OidcConstants.StandardScopes.Profile,
                        OidcConstants.StandardScopes.Email,
                        "api1"
                    }
                },
                new Client{
                    ClientId = "mvc",
                    ClientName = "Mvc Client",
                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                    ClientSecrets = { new Secret("mvc".Sha256())},
                    RedirectUris = {"http://localhost:5002/signin-oidc"},
                    FrontChannelLogoutUri = "http://localhost:5002/signout-oidc",
                    PostLogoutRedirectUris = {"http://localhost:5002/signout-callback-oidc"},
                    AllowOfflineAccess = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AccessTokenLifetime = 60,
                    AllowedScopes = {
                        OidcConstants.StandardScopes.OpenId,
                        OidcConstants.StandardScopes.Profile,
                        OidcConstants.StandardScopes.Email,
                        //"api1"
                    }
                }
            };
        }

        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>()
            {
                new TestUser{
                    SubjectId = "1",
                    Username = "magicybr.wf@outlook.com",
                    Password = "test@password",
                    Claims = new List<Claim>{
                        new Claim(JwtClaimTypes.Email,"magicybr.wf@outlook.com"),
                        new Claim(JwtClaimTypes.Role,"user")
                    }
                }
            };
        }
    }
}