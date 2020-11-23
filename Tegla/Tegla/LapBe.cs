using System;
using System.IO;

namespace FelevesFeladat
{
    class LapBe
    {
        static readonly Random r = new Random();
        private string Q { get; }
        private string[] XY { get; }
        private int N { get; }
        private bool Generator { get; }

        public LapBe(bool Generator)
        {
            if (Generator == true)
            {
                N = r.Next(2, 10001);
                Q = r.Next(0, int.MaxValue).ToString() + " " + r.Next(int.MinValue, 30001).ToString();
                XY = new string[N];
                for (int i = 0; i < N; i++)
                    XY[i] = r.Next(0, int.MaxValue) + " " + r.Next(int.MinValue, 30001);
            }
            this.Generator = Generator;
            Lapbe();
        }
        private void Lapbe()
        {
            if (Generator == true)
            {
                StreamWriter sw = new StreamWriter("LAP.BE.txt");
                for (int i = 0; i < 2 + N; i++)
                {
                    if (i == 0)
                        sw.WriteLine(Q);
                    if (i == 1)
                        sw.WriteLine(N);
                    if (i == 2)
                    {
                        for (int j = 0; j < XY.Length; j++)
                            sw.WriteLine(XY[j]);
                    }
                }
                sw.Close();
            }
        }
    }
}
