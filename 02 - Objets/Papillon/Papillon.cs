using System;

namespace Papillon
{
    public class Papillon : Stade
    {
        public Papillon()
        {
        }

        public override void SeDeplacer()
        {
            Console.WriteLine("Je vole.");
        }

        public override Stade SeMetamorphoser()
        {
            return new Papillon();
        }
    }
}
