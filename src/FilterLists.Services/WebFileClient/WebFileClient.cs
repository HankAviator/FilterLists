using System;
using System.IO;
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
            if (uri.IsFile && Path.GetExtension(uri.AbsoluteUri) == ".txt")
                using (var response = await _httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead))
                using (var streamToReadFrom = await response.Content.ReadAsStreamAsync())
                {
                    using (Stream streamToWriteTo = File.Open(fileName, FileMode.Create))
                    {
                        await streamToReadFrom.CopyToAsync(streamToWriteTo);
                    }
                }
        }
    }
}