using Hangfire.Schedule.ScheduleJobs.Managers;
using Hangfire.Schedule.ScheduleJobs.Managers.Interfaces;

namespace Hangfire.Schedule.ScheduleJobs.FireAndForgets
{
    public class FireAndForgetsJobs : IFireAndForgetsJobs
    {
        public void SendEmail()
        {
            BackgroundJob.Enqueue<IEmailManager>( x => x.SendEmail());
        }
    }
}
