using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FunctionApp1;
using FunctionApp1.Functions;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionApp5
{
    public class Function1
    {
        [FunctionName(nameof(RunOrchestrator))]
        public async Task RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            //var outputs = new List<string>();

            // Replace "hello" with the name of your Durable Activity Function.
            await context.CallActivityAsync(nameof(DealCreation.DealCreate), new Deal() { Id = 1, Name = "Hello1" });
            await context.CallActivityAsync(nameof(DealCreation.DealCreate), new Deal() { Id = 2, Name = "Hello2" });
            await context.CallActivityAsync(nameof(DealCreation.DealCreate), new Deal() { Id = 3, Name = "Hello3" });

        }

        //[FunctionName(nameof(SayHello))]
        //public async Task SayHello([ActivityTrigger] string name)
        //{
        //    Console.WriteLine(name);
        //}

        [FunctionName(nameof(StartAz))]
        public async Task StartAz(
             [TimerTrigger("*/3 * * * * *", RunOnStartup = true, UseMonitor = true)]
             TimerInfo info,
            [DurableClient] IDurableOrchestrationClient context)
        {

            // Function input comes from the request content.
            await context.StartNewAsync(nameof(RunOrchestrator));
        }






        //[FunctionName("Send")]
        //public async Task SendDailyEmail([TimerTrigger(" */4 * * * * *\t")] TimerInfo timerInfo, [DurableClient] IDurableOrchestrationClient starter)
        //{
        //    // await SayHello();
        //}
    }
}