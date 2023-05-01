using SharedProject.cs;

namespace Server.Repositories.Interfaces
{
    public interface IShelterBookingRepository
    {
        void CreateShelterBooking(Shelterbooking shelterBooking);
        void DeleteShelterBooking(int shelterBookingID);
        void UpdateShelterBooking(Shelterbooking shelterBooking);
        Shelterbooking GetShelterBooking(int shelterBookingID);
        List<Shelterbooking> GetAllShelterBookings();
        bool ShelterBookingExists(int shelterBookingID);

        bool ShelterBookingAvailability(string shelter);
    }
}
