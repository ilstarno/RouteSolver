package solver;

public class DirectWay extends Graph {

	final double Sqr(double x) {
		return x * x;
	}

	public DirectWay(double[][] distances) {
		super(distances.length);
		int i, j;
		for (i = 0; i < Nullyfied; i++)
			for (j = 0; j < Nullyfied; j++)
				Connect(i, j, distances[i][j]);
	}
}
