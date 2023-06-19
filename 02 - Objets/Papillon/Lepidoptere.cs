using System;

namespace Papillon
{
    public class Lepidoptere
    {
        Stade stadeCourant;

        public Lepidoptere(Stade _stadeCourant)
        {
            stadeCourant = _stadeCourant;
        }

        public Stade StadeCourant { get => stadeCourant; set => stadeCourant = value; }

        public void SeDeplacer()
        {
            stadeCourant.SeDeplacer();
        }

        public void SeMetamorphoser()
        {
            stadeCourant = stadeCourant.SeMetamorphoser();
        }
    }
}
