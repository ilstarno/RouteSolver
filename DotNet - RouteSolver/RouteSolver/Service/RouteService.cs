using System.Collections.Generic;

/*
 @author Indrit Zeqiri
 @Github https://github.com/ilstarno
 @Linkedin https://www.linkedin.com/in/indrit-zeqiris-3b6b8ba6/
*/
namespace RouteSolver.Service
{
    
    public interface IRouteService
    {
        ICollection<string> CalculateRoute(ICollection<string> locations);
    }
}