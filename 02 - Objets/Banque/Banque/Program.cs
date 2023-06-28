namespace Banque
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banque b = new Banque("Credit Mututu", "Mulhouse");
            
            b.AjouteCompte(1245, "robert", 2_000.00, 300.00);
            b.AjouteCompte(2568, "denis", 1_000.00, 300.00);

            Console.WriteLine(b.ToString());

            //b.RendCompte(1245).Crediter(100);
            //Console.WriteLine(b.RendCompte(1245).Debiter(1000.00));

            Console.WriteLine(b.RendCompte(1245)?.Transferer(b.RendCompte(2568), 2_300.00));
            //Console.WriteLine(b.RendCompte(1245)?.Transferer(b.RendCompte(2568), 5_000.00));

            //Console.WriteLine(b.RendCompte(6789)?.Superieur(b.RendCompte(2568)));
            //Console.WriteLine(b.RendCompte(1245)?.Superieur(b.RendCompte(2568)));
           
            //Console.WriteLine(b.CompteSup());

            Console.WriteLine(b.ToString());
        }
    }
}