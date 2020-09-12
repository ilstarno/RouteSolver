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


