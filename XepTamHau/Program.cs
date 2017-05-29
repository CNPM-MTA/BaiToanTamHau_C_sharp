using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepTamHau
{
    class Program
    {
        const int N = 8;
        //const int TEMP = N - 1;
        static int[] row = new int[N + 1];//quan hậu thứ i đặt trên cột j: xi= j;
        static bool[] col = new bool[N+ 1];// aj= 0=> ô thứ j ko còn trống nữa
        static bool[] toLeft = new bool[2 * N ];//đường chéo b[i+j] không còn trống nữa
        static bool[] toRigh = new bool[2 * N ];//đường chéo c[i-j] không còn trống nưa
        static void Main(string[] args)
        {
            BackTracking bt = new BackTracking(8);
            //bt.placeQueens(0);
            //  int start = 1;
            init();
            func_BackTracking(1);

            Console.ReadKey();
        }
        private static void init()
        {
            int i;
            for (i = 0; i < col.Length; i++)
            {
                row[i] = 0;//hàng i đặt con hậu thứ 0
                col[i] = true;//chưa có 
            }
            for (i = 0; i < toLeft.Length; i++)
            {
                toLeft[i] = true;//chưa có 
                toRigh[i] = true;
            }
        }

        private static void func_BackTracking(int start)
        {
            int j;
            for (j = 1; j <= N; j++)
                if (col[j] && toLeft[start + j-1] && toRigh[start - j + N ])
                {
                    row[start] = j;
                    col[j] = false;
                    toLeft[start + j-1] = false;
                    toRigh[start - j + (N )] = false;
                    if (start <  N )func_BackTracking(start + 1);
                       
                    else
                         showResult();
                       
                    col[j] = true;
                    toLeft[start + j -1] = true;
                    toRigh[start - j + (N)] = true;
                }
        }

        static int n = 0;
        private static void showResult()
        {
            int i;
            Console.WriteLine("n = " + n++);
            for (i = 1; i < row.Length; i++)
                Console.Write("\t" + row[i]);
            Console.WriteLine();
        }
    }
}
