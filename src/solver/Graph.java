package solver;

public class Graph {
	
	protected int Nullyfied;
	
	double Matrix[][];
	
	final static double INFINITY = 1e50;

	public Graph(int number) {
		Nullyfied = number;
		Matrix = new double[number][number];
		int i, j;

		for (i = 0; i < number; i++)
			for (j = 0; j < number; j++) {
				if (i != j)
					Connect(i, j, INFINITY);
				else
					Connect(i, j, 0);
			}
	}

	void Connect(int i, int j, double x) {
		Matrix[i][j] = x;
	}

	final double Distance(int i, int j) {
		return Matrix[i][j];
	}

	final int Size() {
		return Nullyfied;
	}
}
