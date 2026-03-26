using MongoDB.Driver;

namespace ExempleTestMongo.Data
{
    public class MongoContext
    {
        private readonly IMongoDatabase dataBase;

        public MongoContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            dataBase = client.GetDatabase(databaseName);
        }

        internal IMongoCollection<T>? GetCollection<T>(string collectionName)
        {
            return dataBase.GetCollection<T>(collectionName);
        }
    }
}
