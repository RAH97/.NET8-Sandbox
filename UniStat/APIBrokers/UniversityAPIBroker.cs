using UniStat.APIBrokers.BrokerInterfaces;
using UniversityRankingAPI.Models.Entities;

namespace UniStat.APIBrokers
{
    public class UniversityAPIBroker : IUniversityAPIBroker
    {
        private readonly ILogger<UniversityAPIBroker> _logger;
        public UniversityAPIBroker(ILogger<UniversityAPIBroker> logger) 
        {
            _logger = logger;
        }
        public async Task<HttpResponseMessage> Get(Uri uri)
        {
            using(var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(uri);
                    response.EnsureSuccessStatusCode();
                    return response;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw;
                }
            }
        }


    }
}
