using Azure.Messaging.ServiceBus;
using Cosmo.Services.EmailAPI.Models.Dto;
using Cosmo.Services.EmailAPI.Services;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using System.Text;

namespace Cosmo.Services.EmailAPI.Messaging
{
    public class AzureServiceBusConsumer : IAzureServiceBusConsumer
    {
        private readonly string ServiceBusConnectionString;
        private readonly string EmailCartQueue;
        private readonly IConfiguration _config;
        private readonly EmailService _emailService;

        private ServiceBusProcessor _emailCartProcessor;

        public AzureServiceBusConsumer(IConfiguration config, EmailService emailService)
        {
            _config = config;
            ServiceBusConnectionString = _config.GetValue<string>("ServiceBusConnectionString");
            EmailCartQueue = _config.GetValue<string>("TopicAndQueueNames:EmailShoppingCartQueue");
            _emailService = emailService;
            try
            {
                var client = new ServiceBusClient(ServiceBusConnectionString);
                _emailCartProcessor = client.CreateProcessor(EmailCartQueue);
            }
            catch (Exception)
            {
                
            }

        }

        public async Task Start()
        {
            try
            {
                //_emailCartProcessor.ProcessMessageAsync += OnEmailCartRequestReceived;
                //_emailCartProcessor.ProcessErrorAsync += ErrorHandler;
                //await _emailCartProcessor.StartProcessingAsync();
            }
            catch (Exception ex)
            {
                
            }

        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }

        private async Task OnEmailCartRequestReceived(ProcessMessageEventArgs args)
        {
            //this is where you will receive the message
            var message = args.Message;
            var body = Encoding.UTF8.GetString(message.Body);

            CartDto objMessage = JsonConvert.DeserializeObject<CartDto>(body);
            try
            {
                await _emailService.EmailCartAndLog(objMessage);
                await args.CompleteMessageAsync(args.Message);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task Stop()
        {
            try
            {
                await _emailCartProcessor.StopProcessingAsync();
                await _emailCartProcessor.DisposeAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
