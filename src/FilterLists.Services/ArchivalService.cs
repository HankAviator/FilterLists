using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FilterLists.Data;
using Microsoft.EntityFrameworkCore;

namespace FilterLists.Services
{
    public class ArchivalService
    {
        private readonly IFilterListsDbContext dbContext;
        private string _uaString;

        public ArchivalService(IFilterListsDbContext dbContext) => this.dbContext = dbContext;

        public async Task CaptureAsync()
        {
            _uaString = await UserAgentService.GetMostPopularStringAsync();
            var lists = await GetListsToCapture();
        }

        private async Task<IEnumerable<Data.Entities.FilterList>> GetListsToCapture() =>
            await dbContext.FilterLists.ToListAsync();
    }

    public interface IFilterListClient
    {
        Task DownloadAsTxtAsync(Uri uri, string fileName);
    }

    public class FilterListClient : IFilterListClient
    {
        private readonly HttpClient _httpClient;

        public FilterListClient(HttpClient httpClient) => _httpClient = httpClient;

        public async Task DownloadAsTxtAsync(Uri uri, string fileName)
        {
            var message = await _httpClient.GetAsync(uri);
            if (message.IsSuccessStatusCode)
            {
            }
        }
    }
}