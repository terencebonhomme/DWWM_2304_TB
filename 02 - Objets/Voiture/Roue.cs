namespace Voiture
{
    public class Roue
    {
        bool tourne;
        string? dimensionPneu;

        public Roue()
        {
            this.tourne = false;
        }

        public Roue(bool _tourne)
        {
            this.tourne = _tourne;
        }

        public Roue(Roue roueACopier)
        {
            this.tourne = roueACopier.tourne;
            this.dimensionPneu = roueACopier.dimensionPneu;
        }

        public bool Tourne { get => tourne; }

        public bool Tourner()
        {
            bool tournoiementOK;

            if (!this.tourne)
            {
                this.tourne = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Stopper()
        {
            if(this.tourne)
            {
                this.tourne = false;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
