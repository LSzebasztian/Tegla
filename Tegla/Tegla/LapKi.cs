using System;
using System.IO;

namespace FelevesFeladat
{
    class LapKi
    {
        private int[] Q { get; }
        private int[,] XY { get; }
        private int N { get; }
        public LapKi()
        {
            string[] lines = File.ReadAllLines("LAP.BE.txt");
            N = Convert.ToInt32(lines[1]);
            Q = new int[2];
            XY = new int[N, 2];

            string[] helper = lines[0].Split(' ');
            Q[0] = Convert.ToInt32(helper[0]);
            Q[1] = Convert.ToInt32(helper[1]);

            for (int i = 0; i < N; i++)
            {
                string[] helper2 = lines[i + 2].Split(' ');
                XY[i, 0] = Convert.ToInt32(helper2[0]);
                XY[i, 1] = Convert.ToInt32(helper2[1]);
            }
        }
        private int[] Tegla()
        {
            int[,] balpontok = new int[N, 2];
            int[,] jobbpontok = new int[N, 2];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (XY[i, 0] < Q[0] && XY[j, 1] < Q[1])
                    {
                        balpontok[i, 0] = XY[i, 0];
                        balpontok[j, 1] = XY[j, 1];
                    }
                    if (XY[i, 0] > Q[0] && XY[j, 1] > Q[1])
                    {
                        jobbpontok[i, 0] = XY[i, 0];
                        jobbpontok[j, 1] = XY[j, 1];
                    }
                }
            }
            int[] pontok = LegkozelebbiPont(balpontok, jobbpontok);
            if (VanEPontAteglaban(pontok) == true)
            {
                pontok[0] = 0;
                pontok[1] = 0;
                pontok[2] = 0;
                pontok[3] = 0;
                return pontok;
            }
            else
                return pontok;
        }
        private int[,] NullaEltuntetes(int[,] pontok)
        {
            int db = 0;
            for (int i = 0; i < pontok.GetLength(0); i++)
            {
                if (pontok[i, 0] != 0 && pontok[i, 1] != 0)
                    pontok[db++, 0] = pontok[i, 0];
            }
            int[,] NullaNelkuli = new int[db, 2];
            for (int i = 0; i < db; i++)
            {
                if (pontok[i, 0] > 0 || pontok[i, 0] < 0 && pontok[i, 1] > 0 || pontok[i, 1] < 0)
                {
                    NullaNelkuli[i, 0] = pontok[i, 0];
                    NullaNelkuli[i, 1] = pontok[i, 1];
                }
            }
            return NullaNelkuli;
        }
        private int[] LegkozelebbiPont(int[,] balpontok, int[,] jobbpontok0)
        {
            int balX = 0;
            int balY = 0;
            int jobbX = 0;
            int jobbY = 0;
            for (int i = 1; i < balpontok.GetLength(0); i++)
            {
                if (balpontok[i, 0] > balpontok[balX, 0])
                    balX = i;
            }
            for (int i = 1; i < balpontok.GetLength(0); i++)
            {
                if (balpontok[i, 1] > balpontok[balY, 1])
                    balY = i;
            }
            int[,] jobbpontok = NullaEltuntetes(jobbpontok0);
            for (int i = 1; i < jobbpontok.GetLength(0); i++)
            {
                if (jobbpontok[i, 0] < jobbpontok[jobbX, 0])
                    jobbX = i;
            }
            for (int i = 0; i < jobbpontok.GetLength(0); i++)
            {
                if (jobbpontok[i, 1] < jobbpontok[jobbY, 1])
                    jobbY = i;
            }
            int[] pontok = { balpontok[balX, 0], balpontok[balY, 0], jobbpontok[jobbX, 0], jobbpontok[jobbY, 0] };
            return pontok;
        }
        private bool VanEPontAteglaban(int[] pontok)
        {
            bool VanE = true;
            for (int i = 0; i < N; i++)
            {
                if (pontok[0] <= XY[i, 0] && pontok[1] <= XY[i, 1] && pontok[2] >= XY[i, 0] && pontok[3] >= XY[i, 1])
                    VanE = true;
                else
                    VanE = false;
            }
            return VanE;
        }
        public void Lapki()
        {
            StreamWriter sw = new StreamWriter("LAP.KI.txt");
            for (int i = 0; i < 4; i++)
                sw.Write(Tegla()[i] + " ");
            sw.Close();
        }
    }
}
