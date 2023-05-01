using MongoDB.Driver;
using SharedProject.cs;
using Server.Repositories.Interfaces;
using System.Text.Json;

namespace Server.Repositories
{
    public class ShelterBookingRepositoryMongoDB : IShelterBookingRepository
    {
        private const string connectionString = @"mongodb+srv://****:*****@firstcluster0.zvhk7o6.mongodb.net/test";
        private const string databaseName = "ShelterDB";
        private const string collectionName = "Shelterbooking";
        private IMongoCollection<Shelterbooking> collection;
        public ShelterBookingRepositoryMongoDB()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            collection = database.GetCollection<Shelterbooking>(collectionName);
        }

        public void CreateShelterBooking(Shelterbooking shelterBooking)
        {
            shelterBooking.bookingid = GetNextId();
            collection.InsertOne(shelterBooking);
        }

        public void DeleteShelterBooking(int shelterBookingID)
        {
            collection.DeleteOne(item => item.bookingid == shelterBookingID);
        }

        public List<Shelterbooking> GetAllShelterBookings()
        {
            return collection.Find(i => true).ToList();
        }

        public Shelterbooking GetShelterBooking(int shelterBookingID)
        {
            return collection.Find(i => i.bookingid == shelterBookingID).ToList()[0];
        }

        public bool ShelterBookingAvailability(string shelterstring)
        {
            Shelterbooking shelter = JsonSerializer.Deserialize<Shelterbooking>(shelterstring);

            //Console.WriteLine(shelter.shelter.navn);

            List<Shelterbooking> bookings = collection.Find(i => i.Shelter.objekt_id == shelter.shelter.objekt_id).ToList();
            
            foreach (Shelterbooking booking in bookings)
            {
                if (booking.starttime <= shelter.starttime && booking.endtime >= shelter.starttime)
                {
                    return false;
                }
                if (booking.starttime <= shelter.endtime && booking.endtime >= shelter.starttime)
                {
                    return false;
                }
                if (booking.starttime >= shelter.starttime && booking.starttime <= shelter.endtime)
                {
                    return false;
                }
            }
            return true;
        }

        public bool ShelterBookingExists(int shelterBookingID)
        {
            if (collection.Find(i => i.bookingid == shelterBookingID).ToList().Count() > 0)
            {
                return true;
            }
            return false;

        }

        public void UpdateShelterBooking(Shelterbooking shelterBooking)
        {
            collection.ReplaceOne(i => i.bookingid   == shelterBooking.bookingid, shelterBooking);
        }

        public int GetNextId()
        {
            try
            {
                return collection.Find(i => true).SortByDescending(i => i.bookingid).Limit(1).ToList()[0].bookingid + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
