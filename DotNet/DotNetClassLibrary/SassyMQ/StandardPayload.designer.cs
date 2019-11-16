using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace YP.SassyMQ.Lib.RabbitMQ
{
    public partial class StandardPayload
    {

        private StandardPayload(SMQActorBase actor, string content, bool final)
        {
            this.PayloadId = Guid.NewGuid().ToString();

            this.__Actor = actor;
            if (!ReferenceEquals(this.__Actor, null))
            {
                this.SenderId = actor.SenderId.ToString();
                this.SenderName = actor.SenderName;
                this.AccessToken = actor.AccessToken;
            }
            else
            {
                this.SenderId = Guid.NewGuid().ToString();
                this.SenderName = "Unnamed Actor";
                this.AccessToken = null;
            }

            this.Content = content;
        }

        // 0 odxml properties
        
        
        public String ToJSON() 
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        private void HandleReplyTo(object sender, PayloadEventArgs e)
        {
            if (e.Payload.IsHandled && e.BasicDeliverEventArgs.BasicProperties.CorrelationId == this.PayloadId)
            {
                this.ReplyPayload = e.Payload;
                this.ReplyBDEA = e.BasicDeliverEventArgs;
                this.ReplyRecieved = true;
            }
        }

        public Task WaitForReply(PayloadHandler payloadHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var waitTask = Task.Factory.StartNew(() =>
            {
                if (waitTimeout > 0 && !ReferenceEquals(payloadHandler, null))
                {
                    if (ReferenceEquals(this.__Actor, null)) throw new Exception("Can't handle response if payload.__Actor is null");

                    this.__Actor.ReplyTo += this.HandleReplyTo;
                    try
                    {
                        this.TimedOutWaiting = false;
                        var startedAt = DateTime.Now;

                        while (!this.ReplyRecieved && !this.TimedOutWaiting && DateTime.Now < startedAt.AddSeconds(waitTimeout))
                        {
                            Thread.Sleep(100);
                        }
                    }
                    finally
                    {
                        this.__Actor.ReplyTo -= this.HandleReplyTo;
                    }

                    if (!this.ReplyRecieved) this.TimedOutWaiting = true;

                    var errorMessageReceived = !ReferenceEquals(this.ReplyPayload, null) && !String.IsNullOrEmpty(this.ReplyPayload.ErrorMessage);

                    if (this.ReplyRecieved && !errorMessageReceived)
                    {
                        this.ReplyPayload.__Actor = this.__Actor;
                        payloadHandler(this.ReplyPayload, this.ReplyBDEA);
                    }
                    else if (!ReferenceEquals(timeoutHandler, null)) timeoutHandler(this, default(BasicDeliverEventArgs));
                }
            });

            return waitTask;
        }

    }
}