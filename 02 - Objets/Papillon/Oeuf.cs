using System;

namespace Papillon
{
    public class Oeuf : Stade
    {
        public Oeuf()
        {
        }

        public override void SeDeplacer()
        {
            Console.WriteLine("Je ne sais pas me déplacer.");
        }

        public override Stade SeMetamorphoser()
        {
            return new Chenille();
        }
    }
}
