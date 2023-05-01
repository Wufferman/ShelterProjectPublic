using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Server.Repositories.Interfaces;
using Microsoft.AspNetCore.Cors;
using SharedProject.cs;

namespace Server.Controllers
{
    [ApiController]
    [EnableCors("policy")]
    [Route("api/shelterbooking")]
    public class ShelterBookingController
    {
        
        IShelterBookingRepository myRepo;
        public ShelterBookingController(IShelterBookingRepository shelterBookingRepository)
        {
            myRepo = shelterBookingRepository;
        }

        [HttpGet]
        public List<Shelterbooking> GetAllShelterBookings()
        {
            return myRepo.GetAllShelterBookings();
        }

        [HttpGet("{shelterBookingID}")]
        public Shelterbooking GetShelterBooking(int shelterBookingID)
        {
            return myRepo.GetShelterBooking(shelterBookingID);
        }
        [HttpPost]
        public void CreateShelterBooking(Shelterbooking shelterBooking)
        {
            myRepo.CreateShelterBooking(shelterBooking);
        }

        [HttpPut]
        public void UpdateShelterBooking(Shelterbooking shelterBooking)
        {
            myRepo.UpdateShelterBooking(shelterBooking);
        }
        [HttpDelete("{shelterBooking}")]
        public void DeleteShelterBooking(int shelterBooking)
        {
            myRepo.DeleteShelterBooking(shelterBooking);
        }
        [HttpGet("exists/{shelterBookingID}")]
        public bool ShelterBookingExists(int shelterBookingID)
        {
            return myRepo.ShelterBookingExists(shelterBookingID);
        }
        [HttpGet("availability/{shelter}")]
        public bool ShelterBookingAvailability(string shelter)
        {
            return myRepo.ShelterBookingAvailability(shelter);
        }
    }
}
