namespace _1_4_Aire_Volume_Sphere
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double radius = 0, area, volume;
            string saisie;
            bool saisieOk;

            do
            {
                Console.WriteLine("Saisir le rayon de la sphère avec une virgule si nécessaire");
                saisie = Console.ReadLine();
                saisieOk = double.TryParse(saisie, out radius);
            } while (!saisieOk || radius <= 0);

            area = 4 * Math.PI * Math.Pow(radius, 2);
            volume = 4 / 3 * Math.PI * Math.Pow(radius, 3);

            Console.WriteLine("l'aire vaut " + area.ToString("#.##") + " et le volume vaut " + volume.ToString("#.##"));
        }
    }
}