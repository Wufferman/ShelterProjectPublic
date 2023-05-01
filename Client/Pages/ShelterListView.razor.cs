using System.Net.Http.Json;
using System;
using SharedProject.cs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using SharedProject;

namespace Client.Pages
{
    public partial class ShelterListView
    {
        [Parameter]
        public int? kid { get; set; }

        [Parameter]
        public List<Shelter> Shelters { get; set; } = new List<Shelter>();

        public static bool IsValidUrl(string url)
        {
            Uri? uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult) &&
                    (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
        public double[] ConvertCoordinates(string coordsStr)
        {
            string[] cordsArrayString = Array.ConvertAll(coordsStr.Split(','), p => p.Trim().Replace(",", ""));
            //Console.WriteLine(JsonSerializer.Serialize(cordsArrayString));
            double[] cords = new double[2];

            cords[1] = Convert.ToDouble(cordsArrayString[0]);
            cords[0] = Convert.ToDouble(cordsArrayString[1]);

            double longtitude;
            double latitude;

            const double e = 2.7182818284;
            const double X = 20037508.34;

            longtitude = (cords[1] * 180) / X;

            latitude = cords[0] / (X / 180);

            double exponent = (Math.PI / 180) * latitude;

            latitude = Math.Atan(Math.Pow(e, exponent)) / (Math.PI / 360) - 90;


            double[] result = { latitude, longtitude };
            return result;
        }
        public string getCoords(string cords)
        {
            double[] doubles = new double[2];
            doubles = ConvertCoordinates(cords);

            string result = doubles[0] + "," + doubles[1];

            return result;
        }
    }
}
