using System;
using System.Collections.Generic;
using RouteSolver.Service;
using service.remoteservices;

namespace RouteSolver
{
    public class App
    {
        public static void Main(string[] args)
        {
            ICollection<string> qytetet = new List<string>();

            /*
             * We add a list of cities in Albania to solve their best path to visit This
             * example prints on the console the best route between this cities
             */
            qytetet.Add("Tirane");
            qytetet.Add("Durres");
            qytetet.Add("Berat");
            qytetet.Add("Sarande");
            qytetet.Add("Shkoder");
            qytetet.Add("Lezhe");
            qytetet.Add("Tropoje");
            qytetet.Add("Librazhd");
            qytetet.Add("Korce");
            qytetet.Add("Elbasan");

            IRouteService tsps = new GoogleResolverService();
            var route = tsps.CalculateRoute(qytetet);

            Console.Write(route);
        }
    }
}
