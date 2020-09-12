package service.remoteservices;

import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.URL;
import java.net.URLEncoder;
import java.util.ArrayList;
import java.util.Collection;

import com.google.gson.Gson;

import service.RouteService;
import solver.RouteSolver;
import solver.Way;

/*
 	 Please notice that GoogleResolverService uses the Google's Distance Matrix API.
	 Use of the Distance Matrix API must relate to the display of information on a
	 Google Map
  */
public class GoogleResolverService implements RouteService {

	private static final String SERVICE_URL = "https://maps.googleapis.com/maps/api/distancematrix/json?key=000000000";

	private String implodeLocations(Collection<String> locations) {
		String[] locationArray = new String[locations.size()];
		locationArray = locations.toArray(locationArray);

		String implodedString = null;
		if (locationArray.length == 0) {
			implodedString = "";
		} else {
			StringBuffer sb = new StringBuffer();
			sb.append(locationArray[0]);
			for (int i = 1; i < locationArray.length; i++) {
				sb.append("|");
				sb.append(locationArray[i]);
			}
			implodedString = sb.toString();
		}

		return implodedString;
	}

	public Collection<String> CalculateRoute(Collection<String> locations) {
		if (locations == null || locations.size() == 0) {
			return null;
		}
		if (locations.size() >= 1 && locations.size() <= 2) {
			return locations;
		}

		GDistanceMatrixResponse response = null;
		response = getResponse(locations);

		double[][] distances = getDistances(response);
		RouteSolver solver = new RouteSolver(distances);
		Way p = solver.Solve(20);

		return buildResult(p, locations);
	}

	private Collection<String> buildResult(Way p, Collection<String> locations) {
		String[] locationArray = new String[locations.size()];
		locationArray = locations.toArray(locationArray);

		Collection<String> result = new ArrayList<String>();

		int i = 0;
		do {
			result.add(locationArray[i]);
			i = p.To[i];
		} while (i != 0);

		return result;
	}

	private double[][] getDistances(GDistanceMatrixResponse response) {
		double[][] distances = new double[response.getRows().length][response.getRows().length];
		for (int i = 0; i < response.getRows().length; i++) {
			for (int j = 0; j < response.getRows()[i].getElements().length; j++) {
				distances[i][j] = response.getRows()[i].getElements()[j].getDistance().getValue();
			}
		}
		return distances;
	}

	private GDistanceMatrixResponse getResponse(Collection<String> locations) {
		InputStreamReader inputStreamReader = null;
		InputStream inputStream = null;
		try {
			if (locations == null || locations.isEmpty())
				return null;
			Collection<String> encodedLocations = new ArrayList<String>();
			for (String s : locations) {
				String encoded = URLEncoder.encode(s, "UTF-8");
				encodedLocations.add(encoded);
			}
			String implodedLocations = implodeLocations(encodedLocations);
			if (implodedLocations == null || implodedLocations.isEmpty())
				return null;

			StringBuilder stringBuilder = new StringBuilder(SERVICE_URL);
			stringBuilder.append("?origins=");
			stringBuilder.append(implodedLocations);
			stringBuilder.append("&destinations=");
			stringBuilder.append(implodedLocations);
			stringBuilder.append("&sensor=false");

			Gson gson = new Gson();
			inputStream = new URL(stringBuilder.toString()).openStream();
			inputStreamReader = new InputStreamReader(inputStream);
			GDistanceMatrixResponse matrix = gson.fromJson(inputStreamReader, GDistanceMatrixResponse.class);
			inputStreamReader.close();
			return matrix;
		} catch (IOException e) {
			e.printStackTrace();
			try {
				if (inputStreamReader != null)
					inputStreamReader.close();
				if (inputStream != null)
					inputStream.close();
			} catch (IOException io) {
				io.printStackTrace();
			}
			return null;
		}
	}

}
