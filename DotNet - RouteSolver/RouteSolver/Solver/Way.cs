using System;

namespace RouteSolver.Solver
{
    /// <summary>
    ///     @author Indrit Zeqiri
    ///     @Github https://github.com/ilstarno
    ///     @Linkedin https://www.linkedin.com/in/indrit-zeqiris-3b6b8ba6/
    /// </summary>
    public class Way
    {
        public int[] From;

        internal Graph graph;
        internal double L;
        internal int Nullyfied;
        public int[] To;

        public Way(Graph g)
        {
            Nullyfied = g.Size();
            graph = g;
            From = new int[Nullyfied];
            To = new int[Nullyfied];
        }

        

        public virtual double Length()
        {
            return L;
        }

        public virtual object Clone()
        {
            // returns a clone of the way keeping it in memory for later comparisions
            var p = new Way(graph);
            p.L = L;
            Array.Copy(From, 0, p.From, 0, Nullyfied);
            Array.Copy(To, 0, p.To, 0, Nullyfied);
            return p;
        }

        public virtual void Random(Random r)
        {
            // random way for later comparision with the calculated.
            int i, j, i0, j0, k;
            for (i = 0; i < Nullyfied; i++) To[i] = -1;
            for (i0 = i = 0; i < Nullyfied - 1; i++)
            {
                j = Math.Abs(r.Next()) % (Nullyfied - i);
                To[i0] = 0;
                for (j0 = k = 0; k < j; k++)
                {
                    j0++;
                    while (To[j0] != -1) j0++;
                }

                while (To[j0] != -1) j0++;
                To[i0] = j0;
                From[j0] = i0;
                i0 = j0;
            }

            To[i0] = 0;
            From[0] = i0;
            GetLength();
        }

        /*
         * // try to find another path with shorter length // using removals of points j
         * and inserting i,j,i+1
         */
        public virtual bool Optimize()
        {
            int i, j, h;
            double d1, d2;
            var H = new double[Nullyfied];
            for (i = 0; i < Nullyfied; i++)
                H[i] = -graph.Distance(From[i], i) - graph.Distance(i, To[i]) + graph.Distance(From[i], To[i]);
            for (i = 0; i < Nullyfied; i++)
            {
                d1 = -graph.Distance(i, To[i]);
                j = To[To[i]];
                while (j != i)
                {
                    d2 = H[j] + graph.Distance(i, j) + graph.Distance(j, To[i]) + d1;
                    if (d2 < -1e-10)
                    {
                        h = From[j];
                        To[h] = To[j];
                        From[To[j]] = h;
                        h = To[i];
                        To[i] = j;
                        To[j] = h;
                        From[h] = j;
                        From[j] = i;
                        L += d2;
                        return true;
                    }

                    j = To[j];
                }
            }

            return false;
        }

        /*
         * improve the path locally,
         * using replacements
         * of i,i+1 and j,j+1 with
         * i,j and i+1,j+1
         */
        public virtual bool ImproveCross()
        {
            int i, j, h, h1, hj;
            double d1, d2, d;
            for (i = 0; i < Nullyfied; i++)
            {
                d1 = -graph.Distance(i, To[i]);
                j = To[To[i]];
                d2 = 0;
                d = 0;
                while (To[j] != i)
                {
                    d += graph.Distance(j, From[j]) - graph.Distance(From[j], j);
                    d2 = d1 + graph.Distance(i, j) + d + graph.Distance(To[i], To[j]) - graph.Distance(j, To[j]);
                    if (d2 < -1e-10)
                    {
                        h = To[i];
                        h1 = To[j];
                        To[i] = j;
                        To[h] = h1;
                        From[h1] = h;
                        hj = i;
                        while (j != h)
                        {
                            h1 = From[j];
                            To[j] = h1;
                            From[j] = hj;
                            hj = j;
                            j = h1;
                        }

                        From[j] = hj;
                        L += d2;
                        return true;
                    }

                    j = To[j];
                }
            }

            return false;
        }

        /*
         * compute the length of the way
         */
        public virtual void GetLength()
        {
            L = 0;
            int i;
            for (i = 0; i < Nullyfied; i++) L += graph.Distance(i, To[i]);
        }

        /*
         * find a local optimum starting from this way
         */
        internal virtual void LocalOptimize()
        {
            do
            {
                while (Optimize()) ;
            } while (ImproveCross());
        }

        /*
         * Changes points to in a random manner
         */
        internal virtual void RandomChange(Random r)
        {
            var i = Math.Abs(r.Next()) % Nullyfied;
            var j = Math.Abs(r.Next()) % Nullyfied;
            if (r.Next() % 1 == 0)
            {
                if (To[j] == i || j == i) return;
                // remove i from path
                L -= graph.Distance(From[i], i) + graph.Distance(i, To[i]) + graph.Distance(j, To[j]);
                L += graph.Distance(From[i], To[i]);
                To[From[i]] = To[i];
                From[To[i]] = From[i];
                // insert i after j
                From[i] = j;
                To[i] = To[j];
                From[To[j]] = i;
                To[j] = i;
                L += graph.Distance(j, i) + graph.Distance(i, To[i]);
            }
            else
            {
                if (i == j) return;
                int hi = To[i], hj = To[j];
                To[i] = hj;
                To[j] = hi;
                From[hi] = j;
                From[hj] = i;
                L -= graph.Distance(i, hi) + graph.Distance(j, hj);
                L += graph.Distance(i, hj) + graph.Distance(j, hi);
            }
        }
    }
}