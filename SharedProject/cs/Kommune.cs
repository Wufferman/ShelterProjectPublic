using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace SharedProject.cs
{
    public class Kommune
    {
        [BsonElement("_id")]
        [JsonPropertyName("_id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string _id { get; set; }
        public int kommunekode { get; set; }
        public string cvr_navn { get; set; }
        

        public Kommune(int kommunekode, string cvr_navn)
        {
            this.kommunekode = kommunekode;
            this.cvr_navn = cvr_navn;
            
            //Console.WriteLine($"Kommune id: {this.kommuneid} name: {this.name} Oprettet.");
        }
    }
}
