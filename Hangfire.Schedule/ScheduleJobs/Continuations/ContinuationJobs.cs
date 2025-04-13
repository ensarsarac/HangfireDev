using Hangfire.Schedule.ScheduleJobs.Managers.Interfaces;

namespace Hangfire.Schedule.ScheduleJobs.Continuations
{
    public class ContinuationJobs : IContinuationJobs
    {
        private readonly ILogger<ContinuationJobs> _loggerManager;

        public ContinuationJobs(ILogger<ContinuationJobs> loggerManager)
        {
            _loggerManager = loggerManager;
        }

        public void SendEMail()
        {
            var jobId = BackgroundJob.Enqueue<IEmailManager>(x => x.SendEmail());

            // 2. Mail gönderimi bittikten sonra log yaz
            BackgroundJob.ContinueJobWith(jobId, () => _loggerManager.LogInformation("Mail başarıyla gönderildi."));
        }
    }
}
