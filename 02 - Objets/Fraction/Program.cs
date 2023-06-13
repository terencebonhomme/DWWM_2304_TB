namespace Fraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fraction f1 = new Fraction(12, 7);
            Fraction f2 = new Fraction(1);
            Fraction f3 = new Fraction(9);

            Console.WriteLine(f1.ToDisplay());
        }
    }
}