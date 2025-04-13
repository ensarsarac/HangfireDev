using Hangfire.Schedule.ScheduleJobs.Managers.Interfaces;

namespace Hangfire.Schedule.ScheduleJobs.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly ILogger<ProductManager> _logger;

        public ProductManager(ILogger<ProductManager> logger)
        {
            _logger = logger;
        }

        public void GetAllProduct()
        {
            try
            {

                var client = new HttpClient();

                var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7251/api/Products");

                var response = client.Send(request);
                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();

                    _logger.LogInformation("GetAllProduct başarılı bir şekilde çalıştı");
                }
                else
                {
                    _logger.LogError("GetAllProduct çalışma sırasında hata oluştu");
                }
            }
            catch (Exception)
            {

                _logger.LogError("GetAllProduct çalışma sırasında hata oluştu");
            }
        }
    }
}
