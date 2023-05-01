using MongoDB.Driver;
using Server.Repositories.Interfaces;
using SharedProject.cs;

namespace Server.Repositories
{
    public class KommuneRepositoryMongoDB : IKommuneRepository
    {

        private const string connectionString = @"mongodb+srv://****:****@firstcluster0.zvhk7o6.mongodb.net/test";
        private const string databaseName = "ShelterDB";
        private const string collectionName = "Kommuner";
        private IMongoCollection<Kommune> collection;

        public KommuneRepositoryMongoDB() 
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            collection = database.GetCollection<Kommune>(collectionName);
        }

        public List<Kommune> GetAllKommuner()
        {
            return collection.Find(i => true).SortBy(i => i.cvr_navn).ToList();
        }

        public Kommune GetKommune(int id)
        {
            return (Kommune)collection.Find(i => i.kommunekode == id);
        }
    }
}
