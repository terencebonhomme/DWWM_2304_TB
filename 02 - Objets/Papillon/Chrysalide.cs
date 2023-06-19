using System;

namespace Papillon
{
    public class Chrysalide : Stade
    {
        public Chrysalide()
        {
        }

        public override void SeDeplacer()
        {
            Console.WriteLine("Je ne sais pas me déplacer.");
        }

        public override Stade SeMetamorphoser()
        {
            return new Papillon();
        }
    }
}
