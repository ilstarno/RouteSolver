# RouteSolver!

During my work I had to find solutions to calculate best route. 
I chose to do an application that manages technical interventions of a company.
One need was to mash up the application contents with contents from the web. 


So I decided to implement a functionality which tells the drivers what is 
the shortest route in order to visit every customer  and to go back to 
the company’s headquarter.

***

This was clearly a Route > _**Traveling SalesMan Problem**_. 
I solved it using Google Maps API 
and refactoring **[Dr.René Grothmann’s](http://www.rene-grothmann.de/)** solutions 
which i based one of the solvers that today am gonna share with you.


***

The project in question is based on Java initially and then the **.NET** version will 
be available as a library in the Nudget Package Store.
The Java version requires **Gson** to be used to parse the answer coming from Google Maps Servers
You are also required to use a google api key to use the maps you need to place on 
 > RouteResolver > service.remoteservices > GoogleResolverService  - 
### **_private static final String SERVICE_URL = "https://maps.googleapis.com/maps/api/distancematrix/json?key=000000000";_**


# How to use
Basically, I wrote a class called GoogleResolverService from which you can call the method CalculateRoute(). 
This method takes as its only parameter a collection of String that represent the Locations to visit 
(you can use the name of a city or a complete address and google services will find it for you). 
The first element of this collection should be the origin of the route. As result, CalculateRoute() returns 
another String collection that represent the order in which you should visit the locations to have the shortest route.

```java
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
```


