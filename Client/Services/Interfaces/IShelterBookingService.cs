using SharedProject.cs;

namespace Client.Services.Interfaces
{
    public interface IShelterBookingService
    {

        public Task DeleteShelterBooking(int bookingid);

        public Task<List<Shelterbooking>> GetAllShelterBooking();

        public Task<bool> IsShelterAvailable(Shelterbooking booking);

        public Task SubmitBooking(Shelterbooking booking);

    }
}
