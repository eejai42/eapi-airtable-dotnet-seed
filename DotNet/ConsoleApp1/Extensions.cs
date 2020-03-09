using EffortlessApi.SassyMQ.Lib;
using JWT.Algorithms;
using JWT.Builder;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System;
using System.Configuration;
using System.Security.Authentication;

namespace ConsoleApp1
{
    public static class Extensions
    {
        private static JwtBuilder StaticBuilder
        {
            get
            {
                return new JwtBuilder()
                            .WithAlgorithm(new HMACSHA256Algorithm())
                            .WithSecret(C_SECRET);
            }
        }

        static string C_SECRET
        {
            get
            {
                if (ConfigurationManager.AppSettings["JwtSecret"] == null) return "NO SECRET SET";
                else return ConfigurationManager.AppSettings["JwtSecret"];
            }
        }

        private class jwtWrapper<T>
        {
            public long exp { get; set; }
            public T user { get; set; }
        }

        public static T GetJWT<T>(this String jwt, Boolean verifySignature = true)
        {
            if (String.IsNullOrEmpty(jwt)) throw new Exception("Missing JWT in Payload.AccessToken");
            else
            {
                var builder = ((verifySignature) ? StaticBuilder.MustVerifySignature() : StaticBuilder);
                var decodedToken = builder.Decode(jwt);
                var apiUser = JsonConvert.DeserializeObject<jwtWrapper<T>>(decodedToken);
                var expDate = DateTimeOffset.FromUnixTimeSeconds(apiUser.exp);
                if (ReferenceEquals(apiUser, null) || (expDate < DateTime.UtcNow)) throw new AuthenticationException("Invalid jtw");
                else return apiUser.user;
            }
        }

        public static bool FailOnTimeout(this Boolean result) {
            if (!result) throw new Exception("Timed out waiting for a response");
            else return true;
        }

        public static bool HasNoErrors(this StandardPayload payloadWithPossibleError, BasicDeliverEventArgs bdea)
        {
            if (!String.IsNullOrEmpty(payloadWithPossibleError.ErrorMessage)) {
                throw new Exception(String.Format("{0} - {1}", bdea.RoutingKey, payloadWithPossibleError.ErrorMessage));
            }
            else return true;
        }
    }
}
