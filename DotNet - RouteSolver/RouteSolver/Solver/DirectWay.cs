/*
 @author Indrit Zeqiri
 @Github https://github.com/ilstarno
 @Linkedin https://www.linkedin.com/in/indrit-zeqiris-3b6b8ba6/
*/
namespace RouteSolver.Solver
{

	public class DirectWay : Graph
    {

        internal double Sqr(double x)
        {
            return x * x;
        }

        public DirectWay(double[][] distances) : base(distances.Length)
        {
            int i, j;
            for (i = 0; i < Nullyfied; i++)
            {
                for (j = 0; j < Nullyfied; j++)
                {
                    Connect(i, j, distances[i][j]);
                }
            }
        }
    }

}