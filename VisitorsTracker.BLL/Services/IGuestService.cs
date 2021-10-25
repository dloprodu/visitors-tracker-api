using System.Threading.Tasks;
using System.Collections.Generic;
using VisitorsTracker.Models;

namespace VisitorsTracker.BLL.Services
{
    public interface IGuestService
    {
        public Task<PageResult<Guest>> GetNAsync(
            int n = 10,
            int offset = 0,
            string userAgent = null,
            string platform = null,
            string language = null,
            string country = null 
        );

        public Task<Guest> GetByIPAsync(string ip);

        public Task<Guest> CreateAsync(Guest product);
    }
}
