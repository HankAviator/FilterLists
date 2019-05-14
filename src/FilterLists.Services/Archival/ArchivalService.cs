using System.Collections.Generic;
using System.Threading.Tasks;
using FilterLists.Data;
using Microsoft.EntityFrameworkCore;

namespace FilterLists.Services.Archival
{
    public class ArchivalService : IArchivalService
    {
        private readonly FilterListsDbContext dbContext;

        public ArchivalService(FilterListsDbContext dbContext) => this.dbContext = dbContext;

        public async Task ArchiveAllListsAsync()
        {
            var lists = await GetListsToCapture();
        }

        private async Task<IEnumerable<Data.Entities.FilterList>> GetListsToCapture() =>
            await dbContext.FilterLists.ToListAsync();
    }
}