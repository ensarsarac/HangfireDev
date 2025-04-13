using Hangfire.Schedule.ScheduleJobs.Managers;
using Hangfire.Schedule.ScheduleJobs.Managers.Interfaces;

namespace Hangfire.Schedule.ScheduleJobs.RecurringJobs
{
    public class RecurringJobs : IRecurringJobs
    {
        [AutomaticRetry(Attempts = 0)]
        public void GetAllProducts()
        {
            RecurringJob.RemoveIfExists(nameof(ProductManager));
            RecurringJob.AddOrUpdate<IProductManager>(nameof(ProductManager), x => x.GetAllProduct(), Cron.Minutely);
        }

        [AutomaticRetry(Attempts = 0)]
        public void GetCurrency()
        {
            RecurringJob.RemoveIfExists(nameof(CurrencyManager));
            RecurringJob.AddOrUpdate<ICurrencyManager>(nameof(CurrencyManager), x => x.GetCurrency(), Cron.Minutely);
        }
    }
}
