using KafkaCDC.Settings;
using MongoDB.Driver;
using System.Threading.Tasks;
using KafkaCDC.Domain.Mongo;

namespace KafkaCDC.FillMongoConsole
{
    public class MongoDao
    {
        private readonly IMongoDatabase database;

        public MongoDao()
        {
            var client = new MongoClient(MongoSettings.ConnectionString);
            database = client.GetDatabase(MongoSettings.DbName);
        }
        
        private IMongoCollection<Deposit> Authors => database.GetCollection<Deposit>(MongoSettings.CollectionName);
        
        public Task Save(Deposit deposit) => Authors.InsertOneAsync(deposit);
    }
}
