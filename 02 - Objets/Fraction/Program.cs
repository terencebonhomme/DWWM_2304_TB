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

            Console.WriteLine(new Fraction(16, 7) < new Fraction(17, 7));
        }
    }
}