using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilterLists.Services.WebFileClient
{
    public class WebFileClient : IWebFileClient
    {
        private readonly HttpClient _httpClient;

        public WebFileClient(HttpClient httpClient) => _httpClient = httpClient;

        public async Task DownloadAsTxtAsync(Uri uri, string fileName)
        {
            var message = await _httpClient.GetAsync(uri);
            if (message.IsSuccessStatusCode)
            {
            }
        }
    }
}