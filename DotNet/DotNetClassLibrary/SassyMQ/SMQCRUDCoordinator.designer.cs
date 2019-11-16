using System;
using System.Linq;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System.Threading.Tasks;

namespace YP.SassyMQ.Lib.RabbitMQ
{
    public partial class SMQCRUDCoordinator : SMQActorBase
    {

        public SMQCRUDCoordinator(String amqpConnectionString)
            : base(amqpConnectionString, "crudcoordinator")
        {
        }

        protected override void CheckRouting(StandardPayload payload, BasicDeliverEventArgs  bdea)
        {
            var originalAccessToken = payload.AccessToken;
            try
            {
                switch (bdea.RoutingKey)
                {
                    
                    case "crudcoordinator.general.guest.requesttoken":
                        this.OnGuestRequestTokenReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.guest.validatetemporaryaccesstoken":
                        this.OnGuestValidateTemporaryAccessTokenReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.guest.whoami":
                        this.OnGuestWhoAmIReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.guest.whoareyou":
                        this.OnGuestWhoAreYouReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.guest.storetempfile":
                        this.OnGuestStoreTempFileReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.crudcoordinator.resetrabbitsassymqconfiguration":
                        this.OnCRUDCoordinatorResetRabbitSassyMQConfigurationReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.crudcoordinator.resetjwtsecretkey":
                        this.OnCRUDCoordinatorResetJWTSecretKeyReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.admin.addnafstrategy":
                        this.OnAdminAddNAFStrategyReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.admin.getnafstrategies":
                        this.OnAdminGetNAFStrategiesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.admin.getnafstrategybyid":
                        this.OnAdminGetNAFStrategyByIdReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.admin.updatenafstrategy":
                        this.OnAdminUpdateNAFStrategyReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.admin.deletenafstrategy":
                        this.OnAdminDeleteNAFStrategyReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.admin.addgnode":
                        this.OnAdminAddGNodeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.admin.getgnodes":
                        this.OnAdminGetGNodesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.admin.getgnodebyid":
                        this.OnAdminGetGNodeByIdReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.admin.updategnode":
                        this.OnAdminUpdateGNodeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.admin.deletegnode":
                        this.OnAdminDeleteGNodeReceived(payload, bdea);
                        break;
                    
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
        /// Responds to: RequestToken from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestRequestTokenReceived;
        protected virtual void OnGuestRequestTokenReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestRequestTokenReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestRequestTokenReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: ValidateTemporaryAccessToken from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestValidateTemporaryAccessTokenReceived;
        protected virtual void OnGuestValidateTemporaryAccessTokenReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestValidateTemporaryAccessTokenReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestValidateTemporaryAccessTokenReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: WhoAmI from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestWhoAmIReceived;
        protected virtual void OnGuestWhoAmIReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestWhoAmIReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestWhoAmIReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: WhoAreYou from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestWhoAreYouReceived;
        protected virtual void OnGuestWhoAreYouReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestWhoAreYouReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestWhoAreYouReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: StoreTempFile from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestStoreTempFileReceived;
        protected virtual void OnGuestStoreTempFileReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestStoreTempFileReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestStoreTempFileReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: ResetRabbitSassyMQConfiguration from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorResetRabbitSassyMQConfigurationReceived;
        protected virtual void OnCRUDCoordinatorResetRabbitSassyMQConfigurationReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorResetRabbitSassyMQConfigurationReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorResetRabbitSassyMQConfigurationReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: ResetJWTSecretKey from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorResetJWTSecretKeyReceived;
        protected virtual void OnCRUDCoordinatorResetJWTSecretKeyReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorResetJWTSecretKeyReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorResetJWTSecretKeyReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddNAFStrategy from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddNAFStrategyReceived;
        protected virtual void OnAdminAddNAFStrategyReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddNAFStrategyReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddNAFStrategyReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetNAFStrategies from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetNAFStrategiesReceived;
        protected virtual void OnAdminGetNAFStrategiesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetNAFStrategiesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetNAFStrategiesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetNAFStrategyById from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetNAFStrategyByIdReceived;
        protected virtual void OnAdminGetNAFStrategyByIdReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetNAFStrategyByIdReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetNAFStrategyByIdReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateNAFStrategy from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateNAFStrategyReceived;
        protected virtual void OnAdminUpdateNAFStrategyReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateNAFStrategyReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateNAFStrategyReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteNAFStrategy from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteNAFStrategyReceived;
        protected virtual void OnAdminDeleteNAFStrategyReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteNAFStrategyReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteNAFStrategyReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddGNode from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddGNodeReceived;
        protected virtual void OnAdminAddGNodeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddGNodeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddGNodeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetGNodes from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetGNodesReceived;
        protected virtual void OnAdminGetGNodesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetGNodesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetGNodesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetGNodeById from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetGNodeByIdReceived;
        protected virtual void OnAdminGetGNodeByIdReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetGNodeByIdReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetGNodeByIdReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateGNode from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateGNodeReceived;
        protected virtual void OnAdminUpdateGNodeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateGNodeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateGNodeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteGNode from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteGNodeReceived;
        protected virtual void OnAdminDeleteGNodeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteGNodeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteGNodeReceived(this, plea);
            }
        }

        /// <summary>
        /// ResetRabbitSassyMQConfiguration - 
        /// </summary>
        public Task ResetRabbitSassyMQConfiguration(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.ResetRabbitSassyMQConfiguration(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// ResetRabbitSassyMQConfiguration - 
        /// </summary>
        public Task ResetRabbitSassyMQConfiguration(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.ResetRabbitSassyMQConfiguration(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// ResetRabbitSassyMQConfiguration - 
        /// </summary>
        public Task ResetRabbitSassyMQConfiguration(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.general.crudcoordinator.resetrabbitsassymqconfiguration", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// ResetJWTSecretKey - 
        /// </summary>
        public Task ResetJWTSecretKey(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.ResetJWTSecretKey(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// ResetJWTSecretKey - 
        /// </summary>
        public Task ResetJWTSecretKey(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.ResetJWTSecretKey(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// ResetJWTSecretKey - 
        /// </summary>
        public Task ResetJWTSecretKey(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.general.crudcoordinator.resetjwtsecretkey", payload, replyHandler, timeoutHandler, waitTimeout);
        }
    }
}

                    
