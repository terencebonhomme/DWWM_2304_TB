namespace _1_5_Surface_Secteur_Circulaire
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double radius = 0, angle = 0, area;
            string input;
            bool inputOk;

            do
            {
                Console.WriteLine("Saisir le rayon du cercle");
                input = Console.ReadLine();
                inputOk = double.TryParse(input, out radius);
            } while (!inputOk || radius <= 0);

            do
            {
                Console.WriteLine("Saisir l'angle du cercle");
                input = Console.ReadLine();
                inputOk = double.TryParse(input, out angle);
            } while (!inputOk || angle <= 0);

            area = Math.PI * Math.Pow(radius, 2) * angle / 360;

            Console.WriteLine("L'aire du secteur circulaire vaut " + area.ToString("#.##"));
        }
    }
}