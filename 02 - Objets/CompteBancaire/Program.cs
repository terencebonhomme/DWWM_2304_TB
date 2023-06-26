namespace CompteBancaire
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Compte c1 = new Compte(12345, "toto", 2000.00, -500.00);
            Compte c2 = new Compte(12346, "titi", 1000.00, -1000.00);

            List<Compte> listeComptes = new List<Compte> { c1, c2 };

            foreach (Compte c in listeComptes)
            {
                Console.WriteLine(c.ToString());
            }
            
            listeComptes.Sort();

            foreach(Compte c in listeComptes)
            {
                Console.WriteLine(c.ToString());
            }
        }
    }
}