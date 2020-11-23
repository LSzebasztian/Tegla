namespace FelevesFeladat
{
    class Program
    {
        static void Main(string[] args)
        {
            LapBe lapBe = new LapBe(false); // true = új számokat generál | false = nem generál új számokat
            LapKi lapKi = new LapKi();
            lapKi.Lapki();
        }
    }
}
