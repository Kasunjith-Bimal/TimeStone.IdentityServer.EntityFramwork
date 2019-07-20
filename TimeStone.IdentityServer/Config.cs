// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace TimeStone.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
              
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                  new ApiResource("API1","My Demo API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId ="mvc",
                    ClientName="Mvc Demo",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RedirectUris ={ "http://localhost:3728/signin-oidc" },
                    AllowedScopes={ "openid","email","profile","API1"},
                    PostLogoutRedirectUris = { "http://localhost:3728/signout-callback-oidc" },
                    ClientSecrets ={new Secret("secret".Sha256()) }  
                }
               
            };
        }
    }
}