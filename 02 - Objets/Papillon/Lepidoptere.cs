namespace Papillon
{
    public class Lepidoptere
    {
        Stade stadeCourant;

        public Lepidoptere()
        {
            stadeCourant = new Oeuf();
        }

        //public Stade StadeCourant { get => stadeCourant; set => stadeCourant = value; }

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
