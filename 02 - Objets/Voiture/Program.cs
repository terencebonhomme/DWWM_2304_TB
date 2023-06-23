namespace Voiture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Voiture v = new Voiture();

            Roue c = new Roue(Roue.Position.AvantDroite);
            IEnumerable<Roue> distinctRoues = v.Ses4Roues.Distinct();
            Console.WriteLine(distinctRoues.Count());

            foreach (Roue r in distinctRoues)
            {
                Console.WriteLine(r.EmplacementRoue);
            }

            if (v.Ses4Roues != null
                && v.Ses4Roues.Count == 4
                && v.Ses4Roues.Exists(r => r.EmplacementRoue == Roue.Position.AvantDroite)
                && v.Ses4Roues.Exists(r => r.EmplacementRoue == Roue.Position.AvantGauche)
                && v.Ses4Roues.Exists(r => r.EmplacementRoue == Roue.Position.ArriereDroite)
                && v.Ses4Roues.Exists(r => r.EmplacementRoue == Roue.Position.ArriereGauche)
                )
            {
                Console.WriteLine("ok");
            }
            else
            {
                Console.WriteLine("ko");
            }
        }
    }
}