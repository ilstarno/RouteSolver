package solver;

import java.util.Random;

public class RouteSolver {

	private Graph graph;

	public RouteSolver(double[][] distances) {
		graph = new DirectWay(distances);
	}

	public Way Solve(int iterations) {
		Random R = new Random();

		Way pa = new Way(graph);
		Way pmin = null;

		double lmin = 1e50;
		int count = 0;

		do {
			pa.Random(R);
			pa.LocalOptimize();
			if (pa.Length() < lmin - 1e-10) {
				pmin = (Way) pa.Clone();
				lmin = pa.Length();
				pa.GetLength();
				count = 0;
			} else
				count++;
		} while (count < iterations);
		return pmin;
	}
}
