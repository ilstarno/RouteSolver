using System;

namespace RouteSolver.Solver
{
   
    public class RouteSolver
    {
        private readonly Graph graph;

        public RouteSolver(double[][] distances)
        {
            graph = new DirectWay(distances);
        }


        public virtual Way Solve(int iterations)
        {
            var R = new Random();

            var pa = new Way(graph);
            Way pmin = null;

            var lmin = 1e50;
            var count = 0;

            do
            {
                pa.Random(R);
                pa.LocalOptimize();
                if (pa.Length() < lmin - 1e-10)
                {
                    pmin = (Way) pa.Clone();
                    lmin = pa.Length();
                    pa.GetLength();
                    count = 0;
                }
                else
                {
                    count++;
                }
            } while (count < iterations);

            return pmin;
        }
    }
}