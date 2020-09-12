import java.util.ArrayList;
import java.util.Collection;

import service.RouteService;
import service.remoteservices.GoogleResolverService;




/*Please notice that GoogleResolverService uses the Google's Distance Matrix API.
	 Use of the Distance Matrix API must relate to the display of information on a
	 Google Map*/
/**
 * @author Indrit Zeqiri
 * @Github https://github.com/ilstarno
 * @Linkedin https://www.linkedin.com/in/indrit-zeqiris-3b6b8ba6/
 */
public class MainRouteResolver {

	public static void main(String[] args) {
		Collection<String> qytetet = new ArrayList<String>();

		/*
		 * We add a list of cities in Albania to solve their best path to visit This
		 * example prints on the console the best route between this cities
		 */
		qytetet.add("Tirane");
		qytetet.add("Durres");
		qytetet.add("Berat");
		qytetet.add("Sarande");
		qytetet.add("Shkoder");
		qytetet.add("Lezhe");
		qytetet.add("Tropoje");
		qytetet.add("Librazhd");
		qytetet.add("Korce");
		qytetet.add("Elbasan");

		RouteService tsps = new GoogleResolverService();
		Collection<String> route = tsps.CalculateRoute(qytetet);

		System.out.println(route);

	}

}
