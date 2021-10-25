using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;

using VisitorsTracker.DBL.Services;
using VisitorsTracker.DBL;
using VisitorsTracker.Models;
using System;

namespace VisitorsTracker.BLL.Services
{
    /**
     * Guest service that provides methods to fetch and insert visitors.
     */
    public class GuestService : IGuestService
    {
        private readonly IMongoCollection<Guest> _products;        

        public GuestService(MongoService mongo, IDatabaseSettings settings)
        {
            var db = mongo.GetClient().GetDatabase(settings.DatabaseName);
            _products = db.GetCollection<Guest>(settings.CollectionName);
        }

        public async Task<PageResult<Guest>> GetNAsync(
            int n = 10,
            int offset = 0,
            string userAgent = null,
            string platform = null,
            string language = null,
            string country = null
        )
        {
            FilterDefinition<Guest> filter = Builders<Guest>.Filter.Exists(x => x.Id);

            if (!string.IsNullOrEmpty(userAgent))
            {
                filter &= Builders<Guest>.Filter.Eq(x => x.UserAgent, userAgent);
            }

            if (!string.IsNullOrEmpty(platform))
            {
                filter &= Builders<Guest>.Filter.Eq(x => x.Platform, platform);
            }

            if (!string.IsNullOrEmpty(language))
            {
                filter &= Builders<Guest>.Filter.Eq(x => x.Language, language);
            }

            if (!string.IsNullOrEmpty(country))
            {
                filter &= Builders<Guest>.Filter.Eq(x => x.Country, country);
            }

            var total = await _products.CountDocumentsAsync(filter);

            var result = await _products.Find(filter)
                .Skip(offset * n)
                .Limit(n)
                .ToListAsync();

            return new PageResult<Guest> { total = total, result = result };
        }

        public Task<Guest> GetByIPAsync(string ip)
        {
            return _products.Find(p => p.IP == ip).FirstOrDefaultAsync();
        }

        public async Task<Guest> CreateAsync(Guest guest)
        {
            Guest stored = await GetByIPAsync(guest.IP);
            Guest result;

            if (stored == null)
            {
                guest.Visits = 1;
                guest.LastVisit = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");

                await _products.InsertOneAsync(guest, new InsertOneOptions { BypassDocumentValidation = false });

                result = await this.GetByIPAsync(guest.IP);
            }
            else
            {
                result = await this.UpdateAsync(guest);
            }

            return result;
        }


        public async Task<Guest> UpdateAsync(Guest guest)
        {
            var toUpdate = await GetByIPAsync(guest.IP);

            if (toUpdate == null)
            {
                return null;
            }

            guest.Visits = toUpdate.Visits + 1;
            guest.LastVisit = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");

            var result = await _products.FindOneAndReplaceAsync(
                Builders<Guest>.Filter.Eq(p => p.IP, guest.IP),
                guest, 
                new FindOneAndReplaceOptions<Guest> { ReturnDocument = ReturnDocument.After });

            return result;
        }
    }
}