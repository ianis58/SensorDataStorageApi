using MongoDB.Driver;
using SensorDataStorageApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorDataStorageApi.Services
{
    public class MomentService
    {
        private readonly IMongoCollection<Moment> _moments;

        public MomentService(IDht22DatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _moments = database.GetCollection<Moment>(settings.MomentsCollectionName);
        }

        public Moment Create(Moment moment)
        {
            moment.Date = DateTime.Now;
            _moments.InsertOne(moment);
            return moment;
        }
    }
}
