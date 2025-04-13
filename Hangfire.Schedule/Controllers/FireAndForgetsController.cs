using Hangfire.Schedule.ScheduleJobs.FireAndForgets;
using Hangfire.Schedule.ScheduleJobs.Managers;
using Hangfire.Schedule.ScheduleJobs.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.Schedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FireAndForgetsController : ControllerBase
    {

        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IFireAndForgetsJobs _fireAndForgets;

        public FireAndForgetsController(IBackgroundJobClient backgroundJobClient, IFireAndForgetsJobs fireAndForgets)
        {
            _backgroundJobClient = backgroundJobClient;
            _fireAndForgets = fireAndForgets;
        }

        [HttpGet("send-mail")]
        public IActionResult SendMail()
        {
            _backgroundJobClient.Enqueue<IEmailManager>(x => x.SendEmail());
            return Ok("Mail gönderim işi sıraya alındı (Fire-and-Forget)");
        }


        [HttpGet("send-mail-services")]
        public IActionResult SendMailWithServices()
        {
            _fireAndForgets.SendEmail();
            return Ok("Mail gönderim işi servis üzerinden yapıldı ve sıraya alındı (Fire-and-Forget)");
        }
    }
}
