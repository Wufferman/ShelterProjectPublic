using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace SharedProject.cs
{
    [BsonIgnoreExtraElements]
    public class Shelterbooking
    {
        public int bookingid;
        public Shelter shelter;
        public string intention;
        public int participants;
        public Users user;
        public DateTime starttime;
        public DateTime endtime;
        public DateTime bookingTime = DateTime.Now;

        public Shelterbooking(int bookingid, Shelter shelter, DateTime starttime, DateTime endtime, string intention, int participants, Users user)
        {
            this.bookingid = bookingid;
            this.shelter = shelter;
            this.starttime = starttime;
            this.endtime = endtime;
            this.intention = intention;
            this.participants = participants;
            this.user = user;
        }
        public void SetBookingTime(DateTime date)
        {
            this.bookingTime = date;
        }

        public int BookingID { get => this.bookingid; }
        public Shelter Shelter { get => this.shelter; }
        public DateTime Starttime { get => this.starttime; }
        public DateTime Endtime { get => this.endtime; }
        public string Intention { get => this.intention; }
        public int Participants { get => this.participants; }
        public Users User { get => this.user; }
        public DateTime BookingTime { get => this.bookingTime; }


    }
}