using Hangfire.Schedule.ScheduleJobs.Managers.Interfaces;

namespace Hangfire.Schedule.ScheduleJobs.Delayeds
{
    public class DelayedJobs : IDelayedJobs
    {
        public void SendEmail()
        {
            BackgroundJob.Schedule<IEmailManager>(x => x.SendEmail(),TimeSpan.FromSeconds(10)); // 10 saniye sonra çalıştır.
        }
    }
}
