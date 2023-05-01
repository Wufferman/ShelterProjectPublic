using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using ThirdParty.Json.LitJson;

namespace SharedProject.cs
{
    [BsonIgnoreExtraElements]
    public class Shelter
    {

        [BsonElement("_id")]
        [JsonPropertyName("_id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string _id { get; set; }

        public string objekt_id { get; set; }

        public string oprettet { get; set; }

        public int kommunekode { get; set; }

        public int cvr_kode { get; set; }

        public string cvr_navn { get; set; }

        public int statuskode { get; set; }

        public string status { get; set; }

        public string offentlig { get; set; }

        public string facil_ty { get; set; }

        public string navn { get; set; }

        public string beskrivels { get; set; }

        public string lang_beskr { get; set; }

        public string ansvar_org { get; set; }

        public string kontak_ved { get; set; }

        public string handicap { get; set; }

        public int antal_pl { get; set; }

        public string kvalitet { get; set; }

        public string ansva_v { get; set; }

        public string link { get; set; }

        public string coordinates { get; set; }

        public Shelter(string _id,
        string objekt_id,
        string oprettet,
        int kommunekode,
        int cvr_kode,
        string cvr_navn,
        int statuskode,
        string status,
        string offentlig,
        string facil_ty,
        string navn,
        string beskrivels,
        string lang_beskr,
        string ansvar_org,
        string kontak_ved,
        string handicap,
        string ansva_v,
        string link,
        string coordinates,
        int antal_pl,
        string kvalitet
        )
        {
            this._id = _id;
            this.objekt_id = objekt_id;
            this.oprettet = oprettet;
            this.kommunekode = kommunekode;
            this.cvr_kode = cvr_kode;
            this.cvr_navn = cvr_navn;
            this.statuskode = statuskode;
            this.status = status;
            this.offentlig = offentlig;
            this.facil_ty = facil_ty;
            this.navn = navn;
            this.beskrivels = beskrivels;
            this.lang_beskr = lang_beskr;
            this.ansvar_org = ansvar_org;
            this.kontak_ved = kontak_ved;
            this.handicap = handicap;
            this.antal_pl = antal_pl;
            this.kvalitet = kvalitet;
            this.ansva_v = ansva_v;
            this.link = link;
            this.coordinates = coordinates;

            

        }



    }
}
