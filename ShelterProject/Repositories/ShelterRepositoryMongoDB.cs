using SharedProject.cs;
using MongoDB.Driver;
using Server.Repositories.Interfaces;
using System.Text.Json;
using MongoDB.Bson;
using System.Web;

namespace Server.Repositories
{
    public class ShelterRepositoryMongoDB : IShelterRepository
    {
        private const string connectionString = @"mongodb+srv://****:****@firstcluster0.zvhk7o6.mongodb.net/test";
        private const string databaseName = "ShelterDB";
        private const string collectionName = "Shelter";
        private IMongoCollection<Shelter> collection;

        public ShelterRepositoryMongoDB()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            collection = database.GetCollection<Shelter>(collectionName);
        }

        public void CreateShelter(Shelter shelter)
        {
            collection.InsertOne(shelter);
        }

        public void DeleteShelter(Shelter shelter)
        {
            collection.DeleteOne(item => item.objekt_id == shelter.objekt_id);
        }

        public List<Shelter> GetAllShelters()
        {
            return collection.Find(i => i.facil_ty == "Shelter").ToList();
        }
        public List<Shelter> GetKommuneShelters(int kid)
        {

            var x = collection.Find(i => i.kommunekode == kid && i.facil_ty == "Shelter").ToList();
            return x;

        }
        public Shelter GetShelter(string shelter)
        {
            
            return collection.Find(i => i.objekt_id == shelter).ToList()[0];
        }

        public bool ShelterExists(Shelter shelter)
        {
            if (collection.Find(i => i.objekt_id == shelter.objekt_id).ToList().Count() > 0)
            {
                return true;
            }
            return false;
        }

        public void UpdateShelter(Shelter shelter)
        {
            collection.ReplaceOne(i => i.objekt_id == shelter.objekt_id, shelter);
        }
    }
}
