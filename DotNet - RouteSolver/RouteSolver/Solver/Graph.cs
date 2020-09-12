/*
 @author Indrit Zeqiri
 @Github https://github.com/ilstarno
 @Linkedin https://www.linkedin.com/in/indrit-zeqiris-3b6b8ba6/
*/
using System;

namespace RouteSolver.Solver
{
    public class Graph
    {
        internal double[][] Matrix;

        internal int Nullyfied;

        public Graph(int number)
        {
            Nullyfied = number;
            Matrix = RectangularArrays.RectangularDoubleArray(number, number);
            int i, j;

            for (i = 0; i < number; i++)
            for (j = 0; j < number; j++)
                if (i != j)
                    Connect(i, j, Infinity);
                else
                    Connect(i, j, 0);
        }

        internal static double Infinity { get; } = 1e50;

        internal void Connect(int i, int j, double x)
        {
            Matrix[i][j] = x;
        }

        internal double Distance(int i, int j)
        {
            return Matrix[i][j];
        }

        internal int Size()
        {
            return Nullyfied;
        }

        
    }

    internal static class RectangularArrays
    {
        public static double[][] RectangularDoubleArray(int size1, int size2)
        {
            var newArray = new double[size1][];
            for (var array1 = 0; array1 < size1; array1++) newArray[array1] = new double[size2];

            return newArray;
        }
    }
}