using System;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;

namespace SimpleProactiveBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            // calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;

            // return our reply to the user
            await context.PostAsync($"You sent {activity.Text} which was {length} characters");

            ResumptionCookie resumptionCookie = new ResumptionCookie(activity);
            var queueMessage = new QueueMessage
            {
                ResumptionCookie = resumptionCookie,
                MessageText = activity.Text ?? string.Empty
            };

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the queue client.
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a container.
            CloudQueue queue = queueClient.GetQueueReference("botqueue");

            // Create the queue if it doesn't already exist
            queue.CreateIfNotExists();

            CloudQueueMessage messageNew = new CloudQueueMessage(JsonConvert.SerializeObject(queueMessage));
            queue.AddMessage(messageNew);

            context.Wait(MessageReceivedAsync);
        }
    }

    [Serializable]
    public class QueueMessage
    {
        public ResumptionCookie ResumptionCookie;
        public string MessageText;
    }
}