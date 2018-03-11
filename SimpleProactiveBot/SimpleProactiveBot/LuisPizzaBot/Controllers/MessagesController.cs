using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LuisPizzaBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        private static IForm<PizzaOrder> BuildForm()
        {
            var builder = new FormBuilder<PizzaOrder>();

            ActiveDelegate<PizzaOrder> isBYO = (pizza) => pizza.Kind == PizzaOptions.BYOPizza;
            ActiveDelegate<PizzaOrder> isSignature = (pizza) => pizza.Kind == PizzaOptions.SignaturePizza;
            ActiveDelegate<PizzaOrder> isGourmet = (pizza) => pizza.Kind == PizzaOptions.GourmetDelitePizza;
            ActiveDelegate<PizzaOrder> isStuffed = (pizza) => pizza.Kind == PizzaOptions.StuffedPizza;

            return builder
                // .Field(nameof(PizzaOrder.Choice))
                .Field(nameof(PizzaOrder.Size))
                .Field(nameof(PizzaOrder.Kind))
                .Field("BYO.Crust", isBYO)
                .Field("BYO.Sauce", isBYO)
                .Field("BYO.Toppings", isBYO)
                .Field(nameof(PizzaOrder.GourmetDelite), isGourmet)
                .Field(nameof(PizzaOrder.Signature), isSignature)
                .Field(nameof(PizzaOrder.Stuffed), isStuffed)
                .AddRemainingFields()
                .Confirm("Would you like a {Size}, {BYO.Crust} crust, {BYO.Sauce}, {BYO.Toppings} pizza?", isBYO)
                .Confirm("Would you like a {Size}, {&Signature} {Signature} pizza?", isSignature, dependencies: new string[] { "Size", "Kind", "Signature" })
                .Confirm("Would you like a {Size}, {&GourmetDelite} {GourmetDelite} pizza?", isGourmet)
                .Confirm("Would you like a {Size}, {&Stuffed} {Stuffed} pizza?", isStuffed)
                .Build()
                ;
        }

        internal static IDialog<PizzaOrder> MakeRoot()
        {
            return Chain.From(() => new PizzaOrderDialog(BuildForm));
        }

        /// <summary>
        /// POST: api/Messages
        /// receive a message from a user and send replies
        /// </summary>
        /// <param name="activity"></param>
        [ResponseType(typeof(void))]
        public virtual async Task<HttpResponseMessage> Post([FromBody] Activity activity)
        {
            if (activity != null)
            {
                // one of these will have an interface and process it
                switch (activity.GetActivityType())
                {
                    case ActivityTypes.Message:
                        await Conversation.SendAsync(activity, MakeRoot);
                        break;
                    case ActivityTypes.Trigger:
                        var triggeractivity = activity as Activity;
                        var message = JsonConvert.DeserializeObject<QueueMessage>(((JObject)triggeractivity.Value).GetValue("Message").ToString());


                        // send notification
                        var messageactivity = (Activity)message.ResumptionCookie.GetMessage();
                        var client = new ConnectorClient(new Uri(messageactivity.ServiceUrl));
                        Activity replyToConversation = messageactivity.CreateReply();
                        replyToConversation.Recipient = activity.From;
                        replyToConversation.Text = "Notification: " + message.MessageText;
                        await client.Conversations.ReplyToActivityAsync(replyToConversation);

                        // set the next status
                        var queueMessage = new QueueMessage
                        {
                            ResumptionCookie = message.ResumptionCookie
                        };

                        switch (message.MessageText)
                        {
                            case "Order Placed":
                                queueMessage.MessageText = "Order Prepared";
                                QueueManager.EnqueueMessage(queueMessage, 5);
                                break;
                            case "Order Prepared":
                                queueMessage.MessageText = "Order Baked";
                                QueueManager.EnqueueMessage(queueMessage, 10);
                                break;
                            case "Order Baked":
                                queueMessage.MessageText = "Order Boxed";
                                QueueManager.EnqueueMessage(queueMessage, 15);
                                break;
                            case "Order Boxed":
                                queueMessage.MessageText = "Order Delivered, Enjoy your favorite Pizza !! See you again";
                                QueueManager.EnqueueMessage(queueMessage, 5);
                                break;
                        }
                        break;
                    case ActivityTypes.ConversationUpdate:
                    case ActivityTypes.ContactRelationUpdate:
                    case ActivityTypes.Typing:
                    case ActivityTypes.DeleteUserData:
                    default:
                        Trace.TraceError($"Unknown activity type ignored: {activity.GetActivityType()}");
                        break;
                }
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
        }
    }
}