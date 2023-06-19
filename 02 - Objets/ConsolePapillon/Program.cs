using Papillon;

namespace ConsolePapillon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lepidoptere lepidoptere;
            int i;

            lepidoptere = new Lepidoptere(new Oeuf());

            i = 0;
            while(i < 5)
            {
                lepidoptere.SeDeplacer();
                lepidoptere.SeMetamorphoser();
                i++;
            }                        
        }
    }
}