using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
//using GoogleApi.Entities.Common;
//using GoogleApi.Entities.Maps.Directions.Request;
//using GoogleApi.Entities.Maps.Directions.Response;

namespace DL
{
    class Class1
    {

        public void GetRoute()
        {
            //DirectionsRequest request = new DirectionsRequest();

            //request.Key = "AIzaSyAJgBs8LYok3rt15rZUg4aUxYIAYyFzNcw";

            //request.Origin = new Location("Brasov");
            //request.Destination = new Location("Merghindeal");

            //var response = GoogleApi.GoogleMaps.Directions.Query(request);

            //Console.WriteLine(response.Routes.First().Legs.First().DurationInTraffic);
            //Console.WriteLine(response.Routes.First().Legs.First().Distance);
            //Console.WriteLine(response.Routes.First().Legs.First().Steps);


            string url = @"https://maps.googleapis.com/maps/api/directions/json?origin=הר+נוף&destination=גבעת+שאול&key=AIzaSyCOrzabjz4LEcTzpvjmFEdrlLaYhUlzb5I";

            WebRequest request = WebRequest.Create(url);

            WebResponse response = request.GetResponse();

            Stream data = response.GetResponseStream();

            StreamReader reader = new StreamReader(data);
            Console.WriteLine(data.ToString());
            // json-formatted string from maps api
            string responseFromServer = reader.ReadToEnd();

            response.Close();

        } 
}
}
