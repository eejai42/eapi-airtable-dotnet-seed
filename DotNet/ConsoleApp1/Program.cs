using Newtonsoft.Json;
using System;
using YP.SassyMQ.Lib.RabbitMQ;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var amqps = "amqps://smqPublic:smqPublic@effortlessapi-rmq.ssot.me/jmillar-naf";
            var guest = new SMQGuest(amqps);
            var payload = guest.CreatePayload();
            payload.EmailAddress = "test@test.com";
            payload.DemoPassword = "password123";
            guest.ValidateTemporaryAccessToken(payload, (reply, bdea) =>
            {
                var admin = new SMQAdmin(amqps);
                admin.AccessToken = reply.AccessToken;
                payload = admin.CreatePayload();

                admin.GetNAFStrategies(payload, (nsReply, nsBdea) =>
                {
                    Console.WriteLine(JsonConvert.SerializeObject(nsReply.NAFStrategies));
                }, (error, ebdea) =>
                {
                    Console.WriteLine("ERROR: {0}", error.ErrorMessage);
                });
            }, (error, ebdea) =>
            {
                Console.WriteLine("ERROR: {0}", error.ErrorMessage);
            });
            Console.ReadKey();
        }
    }
}
