using Hangfire.Schedule.ScheduleJobs.Managers.Interfaces;

namespace Hangfire.Schedule.ScheduleJobs.Managers
{
    public class CurrencyManager : ICurrencyManager
    {
        private readonly ILogger<CurrencyManager> _logger;

        public CurrencyManager(ILogger<CurrencyManager> logger)
        {
            _logger = logger;
        }
        public void GetCurrency()
        {
            try
            {

                var client = new HttpClient();

                var request = new HttpRequestMessage(HttpMethod.Get, "https://www.tcmb.gov.tr/kurlar/today.xml");

                var response = client.Send(request);
                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();

                    var content = response.Content.ReadAsStringAsync().Result;

                    Console.WriteLine("Currency Response:");
                    Console.WriteLine(content);

                    _logger.LogInformation("Currency Response: {CurrencyContent}", content);
                    _logger.LogInformation("GetCurrency başarılı bir şekilde çalıştı");
                }
                else
                {
                    _logger.LogError("GetCurrency çalışma sırasında hata oluştu");
                }
            }
            catch (Exception)
            {

                _logger.LogError("GetCurrency çalışma sırasında hata oluştu");
            }
        }
    }
}
