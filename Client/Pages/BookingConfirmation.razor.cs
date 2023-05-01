using Microsoft.AspNetCore.Components;
using MongoDB.Driver.Core.Bindings;
using MongoDB.Driver.Linq;
using System.Text.Json;
using System.Web;

namespace Client.Pages
{
    public partial class BookingConfirmation
    {
        [Parameter]
        public string Coordinates { get; set; } = "Not Defined";
        public string[] Coords { get; set; }

        public double[] CorrectCoordinates { get; set; }


        protected override async Task OnInitializedAsync()
        {
            //Coordinates = HttpUtility.UrlDecode(Coordinates);
            Coordinates = HttpUtility.UrlDecode(Coordinates);
            Coords = Array.ConvertAll(Coordinates.Split(','), p => p.Trim().Replace(",", ""));
            //Coords[0] = Coords[0].Replace(".", ",");
            //Coords[1] = Coords[1].Replace(".", ",");
            //Console.WriteLine(JsonSerializer.Serialize(Coords));
            CorrectCoordinates = ConvertCoordinates(Coords);
            //Console.WriteLine(JsonSerializer.Serialize(CorrectCoordinates));
            //Console.WriteLine(Coordinates);
            //Console.WriteLine();
            //Console.WriteLine(Coords[1]);
            Coordinates = CorrectCoordinates[0] + "," + CorrectCoordinates[1];
            //Console.WriteLine(Coordinates);
        }

        public double[] ConvertCoordinates(string[] coordsStr)
        {
            double[] cords = new double[2];

            cords[1] = Convert.ToDouble(coordsStr[0]);
            cords[0] = Convert.ToDouble(coordsStr[1]);

            double longtitude;
            double latitude;

            const double e = 2.7182818284;
            const double X = 20037508.34;

            longtitude = (cords[1] * 180) / X;

            latitude = cords[0] / (X / 180);

            double exponent = (Math.PI / 180) * latitude;
            
            latitude = Math.Atan(Math.Pow(e, exponent)) / (Math.PI /360) - 90;


            double[] result = { latitude, longtitude };

            return result;
        }

        //public static List<int> coords = new();
        //public static List<string> coordsStr = new();
        //private LeafletMap.Coordinate Coordinate;

        //public BookingConfirmation(){
        //    coordinates = HttpUtility.UrlDecode(coordinates);
        //    coordsStr = coordinates.Split(',').Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        //    foreach(string s in coordsStr)
        //    {
        //        Console.WriteLine(s);
        //        coords.Add(Convert.ToInt32(s));
        //    }
        //    Coordinate = new LeafletMap.Coordinate { Lat = coords[0], Lng = coords[1] };
        //    //}
        //}
    }
}
