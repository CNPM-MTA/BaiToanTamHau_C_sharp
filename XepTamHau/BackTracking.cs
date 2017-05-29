using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepTamHau
{
    public class BackTracking
    {
        private int[] solution;
        private int N;
        private BackTracking() { }
        public BackTracking(int N)
        {
            solution = new int[N];
            this.N = N;
            int i;
            for (i = 0; i < N; i++)
                solution[i] = 0;
        }
        int count = 0;
        public void show(int N)
        {
            int i;
            Console.WriteLine("\n(" + count++ + ")");
            for (i = 0; i < N; i++)
                Console.Write("\t" + solution[i]);
        }
        public void placeQueens(int row)
        {
            int i = 0;
            for (i = 0; i < N; i++)
                if (canPlace(row, i))
                {
                    solution[row] = i;
                    if (row == N - 1)
                        show(N);
                    placeQueens(row + 1);
                }
        }
        /*
         x1==x2 means same rows,
         y1==y2 means same columns
         |x2-x1|==|y2-y1| means they are placed in diagonals.
        */
        public Boolean canPlace(int x2, int y2)
        {
            int i;
            for (i = 0; i < x2; i++)
            {
                if (solution[i] == y2 || (Math.Abs(i - x2) == Math.Abs(solution[i] - y2)))
                    return false;
            }
            return true;
        }
    }
}
