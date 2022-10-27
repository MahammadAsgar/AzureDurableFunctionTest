using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp1.Functions
{
    public sealed class DealCreation
    {
        [FunctionName(nameof(DealCreate))]
        public async Task<Deal> DealCreate([ActivityTrigger] Deal deal)
        {
            return deal;
        }
    }
}
