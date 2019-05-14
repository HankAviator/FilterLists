using System;
using System.Threading.Tasks;

namespace FilterLists.Services.WebFileClient
{
    public interface IWebFileClient
    {
        Task DownloadAsTxtAsync(Uri uri, string fileName);
    }
}