using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;

namespace IdsWithAspIds
{
    public class Config
    {
        // scopes define the resources in your system
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            var customProfile = new IdentityResource(
                name: "application.profile",
                displayName: "Application profile",
                claimTypes: new[] { JwtClaimTypes.Email, JwtClaimTypes.GivenName, JwtClaimTypes.FamilyName}
            );

            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                customProfile,
                new IdentityResource("roles", new string[] { JwtClaimTypes.Role })
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api", "My API")
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {

            var secret = new Secret { Value = "mysecret".Sha512() };

            // client credentials client
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api1" }
                },


                 new Client {
                    ClientId = "authorizationCodeClient2",
                    ClientName = "Authorization Code Client",
                    Enabled = true,
                    AllowedGrantTypes = new List<string> { "authorization_code" },
                    RequireConsent = false,
                    AllowRememberConsent = false,
                    RedirectUris =
                        new List<string> {
                            "http://localhost:5436/account/oAuth2"
                        },
                    PostLogoutRedirectUris =
                        new List<string> {"http://localhost:5436"},

                    ClientSecrets = new List<Secret> { secret },
                    AllowedScopes = new List<string> {
                    "api"
                },
                    AccessTokenType = AccessTokenType.Jwt
                },

                // resource owner password grant client
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api1" }
                },

                // OpenID Connect hybrid flow and client credentials client (MVC)
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    RequireConsent = false,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris = { "http://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    },
                    AllowOfflineAccess = true
                },

                 new Client
                {
                    ClientId = "umbraco",
                    ClientName = "Umbraco Client",
                    AllowedGrantTypes = GrantTypes.Implicit,

                    RequireConsent = false,

                    RedirectUris = { "http://localhost:5001/" },
                    PostLogoutRedirectUris = { "http://localhost:5001/" },

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "roles"
                    }
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "121212",
                    Username = "test",
                    Password = "password",
                    Claims = new List<Claim> {
                        new Claim(JwtClaimTypes.Email, "test@test.com"),
                        new Claim(JwtClaimTypes.GivenName, "Test"),
                        new Claim(JwtClaimTypes.FamilyName, "User"),
                        new Claim(JwtClaimTypes.Name, "Test User"),
                        new Claim(JwtClaimTypes.Role, "Standard User"),
                    }
                }
            };
        }
    }
}