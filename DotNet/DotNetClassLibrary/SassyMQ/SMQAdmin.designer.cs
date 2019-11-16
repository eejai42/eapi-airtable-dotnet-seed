using System;
using System.Linq;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System.Threading.Tasks;

namespace YP.SassyMQ.Lib.RabbitMQ
{
    public partial class SMQAdmin : SMQActorBase
    {

        public SMQAdmin(String amqpConnectionString)
            : base(amqpConnectionString, "admin")
        {
        }

        protected override void CheckRouting(StandardPayload payload, BasicDeliverEventArgs  bdea)
        {
            var originalAccessToken = payload.AccessToken;
            try
            {
                switch (bdea.RoutingKey)
                {
                    
                }

            }
            catch (Exception ex)
            {
                payload.ErrorMessage = ex.Message;
            }
            if (payload.AccessToken == originalAccessToken) payload.AccessToken = null;            
            this.Reply(payload, bdea.BasicProperties);
        }

        /// <summary>
        /// AddNAFStrategy - 
        /// </summary>
        public Task AddNAFStrategy(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddNAFStrategy(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// AddNAFStrategy - 
        /// </summary>
        public Task AddNAFStrategy(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddNAFStrategy(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddNAFStrategy - 
        /// </summary>
        public Task AddNAFStrategy(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.general.admin.addnafstrategy", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// GetNAFStrategies - 
        /// </summary>
        public Task GetNAFStrategies(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetNAFStrategies(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// GetNAFStrategies - 
        /// </summary>
        public Task GetNAFStrategies(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetNAFStrategies(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetNAFStrategies - 
        /// </summary>
        public Task GetNAFStrategies(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.general.admin.getnafstrategies", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// GetNAFStrategyById - 
        /// </summary>
        public Task GetNAFStrategyById(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetNAFStrategyById(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// GetNAFStrategyById - 
        /// </summary>
        public Task GetNAFStrategyById(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetNAFStrategyById(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetNAFStrategyById - 
        /// </summary>
        public Task GetNAFStrategyById(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.general.admin.getnafstrategybyid", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// UpdateNAFStrategy - 
        /// </summary>
        public Task UpdateNAFStrategy(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateNAFStrategy(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// UpdateNAFStrategy - 
        /// </summary>
        public Task UpdateNAFStrategy(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateNAFStrategy(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateNAFStrategy - 
        /// </summary>
        public Task UpdateNAFStrategy(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.general.admin.updatenafstrategy", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// DeleteNAFStrategy - 
        /// </summary>
        public Task DeleteNAFStrategy(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteNAFStrategy(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// DeleteNAFStrategy - 
        /// </summary>
        public Task DeleteNAFStrategy(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteNAFStrategy(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteNAFStrategy - 
        /// </summary>
        public Task DeleteNAFStrategy(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.general.admin.deletenafstrategy", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// AddGNode - 
        /// </summary>
        public Task AddGNode(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AddGNode(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// AddGNode - 
        /// </summary>
        public Task AddGNode(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AddGNode(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AddGNode - 
        /// </summary>
        public Task AddGNode(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.general.admin.addgnode", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// GetGNodes - 
        /// </summary>
        public Task GetGNodes(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetGNodes(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// GetGNodes - 
        /// </summary>
        public Task GetGNodes(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetGNodes(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetGNodes - 
        /// </summary>
        public Task GetGNodes(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.general.admin.getgnodes", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// GetGNodeById - 
        /// </summary>
        public Task GetGNodeById(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetGNodeById(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// GetGNodeById - 
        /// </summary>
        public Task GetGNodeById(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetGNodeById(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetGNodeById - 
        /// </summary>
        public Task GetGNodeById(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.general.admin.getgnodebyid", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// UpdateGNode - 
        /// </summary>
        public Task UpdateGNode(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.UpdateGNode(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// UpdateGNode - 
        /// </summary>
        public Task UpdateGNode(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.UpdateGNode(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// UpdateGNode - 
        /// </summary>
        public Task UpdateGNode(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.general.admin.updategnode", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// DeleteGNode - 
        /// </summary>
        public Task DeleteGNode(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DeleteGNode(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// DeleteGNode - 
        /// </summary>
        public Task DeleteGNode(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DeleteGNode(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DeleteGNode - 
        /// </summary>
        public Task DeleteGNode(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.general.admin.deletegnode", payload, replyHandler, timeoutHandler, waitTimeout);
        }
    }
}

                    
