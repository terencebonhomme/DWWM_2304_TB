namespace Fraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fraction f1 = new Fraction(12, 7);
            Fraction f2 = new Fraction(1);
            Fraction f3 = new Fraction(9);

            Fraction fa = new Fraction(11, 7);
            Fraction fb = new Fraction(17, 5);
            Fraction fc = new Fraction(17, 8);

            //Fraction fa = new Fraction(2, 4);
            //Fraction fb = new Fraction(1, 2);

            //Console.WriteLine(fc);
            
            Console.WriteLine(fb.Divise(fc));

            //Console.WriteLine("test");
            //Console.WriteLine(fa.GetPgcd(fb));
            //Console.WriteLine(fa.Plus(fb).ToString());
            //Console.WriteLine(f4.Numerateur);
            //Console.WriteLine(f4.Denominateur);
            //Console.WriteLine(f1.);

        }
    }
}