using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

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
                new ApiResource("api1","这里是测试资源")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client{
                   ClientId = "ngClient",
                   ClientName = "ngClient",
                   ClientUri = "http://localhost:4200",
                   AllowedGrantTypes = GrantTypes.Implicit,
                   AllowAccessTokensViaBrowser = true,
                   RequireConsent = true,
                   AccessTokenLifetime = 60,
                   RedirectUris = {
                       "http://localhost:4200/callback.html",
                       "http://localhost:4200/renew-callback.html"
                   },
                   PostLogoutRedirectUris = {
                       "http://localhost:4200/signout-callback.html"
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
                    AccessTokenLifetime = 60, // 设置token超时时间
                    AllowedScopes = {
                        OidcConstants.StandardScopes.OpenId,
                        OidcConstants.StandardScopes.Profile,
                        OidcConstants.StandardScopes.Email,
                        "api1"
                    }
                },
                new Client
                {
                    ClientId = "swagger_client_api",
                    ClientName = "Swagger UI for api",
                    // ClientSecrets = { new Secret("client".Sha256())},
                    AllowedGrantTypes = GrantTypes.Implicit, // 指定允许的授权类型（AuthorizationCode，Implicit，Hybrid，ResourceOwner，ClientCredentials的合法组合）。
                    AllowAccessTokensViaBrowser = true,      // 是否通过浏览器为此客户端传输访问令牌
                    AllowOfflineAccess = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AccessTokenLifetime = 60,                // 设置token超时时间
                    RedirectUris =
                    {
                        "http://localhost:5001/swagger/oauth2-redirect.html"
                    },
                    AllowedScopes = {
                        OidcConstants.StandardScopes.OpenId,
                        OidcConstants.StandardScopes.Profile,
                        OidcConstants.StandardScopes.Email,
                        "api1"
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