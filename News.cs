using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HockeyNewsBot
{
    public class News
    {
        private HttpClient _httpClient { get; set; }
        private Settings _settings { get; set; }

        public News(Settings settings)
        {
            _settings = settings;
            _httpClient = new HttpClient();
        }
        public async Task<NewsData> GetNews()
        {
            var result = await _httpClient.GetStringAsync(_settings.RotoworldApiUrl);
            var data = JsonConvert.DeserializeObject<NewsData>(result);
            return data;
        }
    }
}