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
                tournoiementOK = true;
            }
            else
            {
                tournoiementOK = false;
            }

            return tournoiementOK;
        }

        public bool Stopper()
        {
            bool stopOK;

            if(this.tourne)
            {
                this.tourne = false;
                stopOK = true;
            }
            else
            {
                stopOK = false;
            }

            return stopOK;
        }
    }
}
