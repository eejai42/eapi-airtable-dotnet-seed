using JWT.Algorithms;
using JWT.Builder;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Security.Authentication;

namespace ConsoleApp1
{
    public static class Extensions
    {
        private static JwtBuilder builder
        {
            get
            {
                return new JwtBuilder()
                            .WithAlgorithm(new HMACSHA256Algorithm())
                            .WithSecret("51DA01A3-8089-439C-89FD-C7227C631AB5");
            }
        }

        static string C_SECRET { get { return ConfigurationManager.AppSettings["JwtSecret"]; } }

        private class jwtWrapper<T>
        {
            public long exp { get; set; }
            public T user { get; set; }
        }

        public static T GetJWT<T>(this String jwt)
        {
            if (String.IsNullOrEmpty(jwt)) throw new Exception("Missing JWT in Payload.AccessToken");
            else
            {
                var decodedToken = builder
                        .MustVerifySignature()
                        .Decode(jwt);
                var apiUser = JsonConvert.DeserializeObject<jwtWrapper<T>>(decodedToken);
                var expDate = DateTimeOffset.FromUnixTimeSeconds(apiUser.exp);
                if (ReferenceEquals(apiUser, null) || (expDate < DateTime.UtcNow)) throw new AuthenticationException("Invalid jtw");
                else return apiUser.user;
            }
        }

    }
}
