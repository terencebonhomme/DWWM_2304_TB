using System;

namespace Papillon
{
    public class Chenille : Stade
    {
        public Chenille()
        {
        }

        public override void SeDeplacer()
        {
            Console.WriteLine("Je rampe.");
        }

        public override Stade SeMetamorphoser()
        {
            return new Chrysalide();
        }
    }
}
