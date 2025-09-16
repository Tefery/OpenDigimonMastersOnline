using ODMO.Admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODMO.Admin.Services
{
    public interface IDownloadService
    {
        Task<DownloadResult> GetDownloadAsync(string fileName, string architecture);
        bool IsValidDownloadRequest(string fileName, string architecture);
        IEnumerable<DownloadInfo> GetAvailableDownloads();
    }
}
