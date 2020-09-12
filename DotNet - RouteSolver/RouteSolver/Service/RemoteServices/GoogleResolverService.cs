using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using RouteSolver.Service;
using RouteSolver.Service.RemoteServices;
using RouteSolver.Solver;

/*
 @author Indrit Zeqiri
 @Github https://github.com/ilstarno
 @Linkedin https://www.linkedin.com/in/indrit-zeqiris-3b6b8ba6/
*/
namespace service.remoteservices
{

   
    /*
        Please notice that GoogleResolverService uses the Google's Distance Matrix API.
        Use of the Distance Matrix API must relate to the display of information on a
        Google Map
    */
    public class GoogleResolverService : IRouteService
    {
        private static readonly string ServiceUrl = "https://maps.googleapis.com/maps/api/distancematrix/json?key=000000000";


        public virtual ICollection<string> CalculateRoute(ICollection<string> locations)
        {
            if (locations == null || locations.Count == 0) return null;
            if (locations.Count >= 1 && locations.Count <= 2) return locations;

            GDistanceMatrixResponse response = null;
            response = GetResponse(locations);

            var distances = getDistances(response);
            var solver = new RouteSolver.Solver.RouteSolver(distances);
            var p = solver.Solve(20);

            return BuildResult(p, locations);
        }

        private string ImplodeLocations(ICollection<string> locations)
        {
            var locationArray = locations.ToArray();

            string implodedString = null;
            if (implodedString == null)
            {
                throw new ArgumentNullException(nameof(implodedString));
            }
            if (locationArray.Length == 0)
            {
                implodedString = "";
            }
            else
            {
                var sb = new StringBuilder();
                sb.Append(locationArray[0]);
                for (var i = 1; i < locationArray.Length; i++)
                {
                    sb.Append("|");
                    sb.Append(locationArray[i]);
                }

                implodedString = sb.ToString();
            }

            return implodedString;
        }

        public static ICollection<string> BuildResult(Way p, ICollection<string> locations)
        {
            string[] locationArray;
            locationArray = locations.ToArray();

            ICollection<string> result = new List<string>();

            var i = 0;
            do
            {
                result.Add(locationArray[i]);
                i = p.To[i];
            } while (i != 0);

            return result;
        }

        private double[][] getDistances(GDistanceMatrixResponse response)
        {
            var distances = RectangularArrays.ReturnRectangularDoubleArray(response.Rows.Length, response.Rows.Length);
            for (var i = 0; i < response.Rows.Length; i++)
            for (var j = 0; j < response.Rows[i].Elements.Length; j++)
                distances[i][j] = response.Rows[i].Elements[j].Distance.Value;
            return distances;
        }

        private GDistanceMatrixResponse GetResponse(ICollection<string> locations)
        {
            StreamReader inputStreamReader = null;
            Stream inputStream = null;
            try
            {
                if (locations == null || locations.Count == 0) return null;
                ICollection<string> encodedLocations = new List<string>();
                foreach (var s in locations)
                {
                    var encoded = HttpUtility.UrlEncode(s, Encoding.UTF8);
                    encodedLocations.Add(encoded);
                }

                var implodedLocations = ImplodeLocations(encodedLocations);
                if (ReferenceEquals(implodedLocations, null) || implodedLocations.Length == 0) return null;

                var stringBuilder = new StringBuilder(ServiceUrl);
                stringBuilder.Append("?origins=");
                stringBuilder.Append(implodedLocations);
                stringBuilder.Append("&destinations=");
                stringBuilder.Append(implodedLocations);
                stringBuilder.Append("&sensor=false");


                inputStream = new WebClient().OpenRead(stringBuilder.ToString());
                inputStreamReader = new StreamReader(inputStream ?? throw new InvalidOperationException());
                var matrix = JsonConvert.DeserializeObject<GDistanceMatrixResponse>(inputStreamReader.ToString());


                inputStreamReader.Close();
                return matrix;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
                Console.Write(e.StackTrace);
                try
                {
                    if (inputStreamReader != null) inputStreamReader.Close();
                    if (inputStream != null) inputStream.Close();
                }
                catch (IOException io)
                {
                    Console.WriteLine(io.ToString());
                    Console.Write(io.StackTrace);
                }

                return null;
            }
        }
    }
}

internal static class RectangularArrays
{
    internal static double[][] ReturnRectangularDoubleArray(int size1, int size2)
    {
        var newArray = new double[size1][];
        for (var array1 = 0; array1 < size1; array1++) newArray[array1] = new double[size2];

        return newArray;
    }
}