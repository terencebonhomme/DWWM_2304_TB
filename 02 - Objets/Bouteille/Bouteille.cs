namespace Bouteille
{
    public class Bouteille
    {
        public double CapaciteEnCl { get; private set; }
        public double QuantiteEnCl { get; private set; }
        public string Contenu { get; private set; }
        public bool EstOuverte { get; private set; }

        public Bouteille(string _contenu, bool _estOuverte, double _quantiteEnCl, double _capaciteEnCl)
        {
            this.Contenu = _contenu;
            this.EstOuverte = _estOuverte;
            this.QuantiteEnCl = _quantiteEnCl;
            this.CapaciteEnCl = _capaciteEnCl;
        }

        public Bouteille() : this("eau", true, 100, 150)
        {

        }

        public Bouteille(Bouteille bouteilleACopier)
        {
            Contenu = bouteilleACopier.Contenu;
            EstOuverte = bouteilleACopier.EstOuverte;
            QuantiteEnCl = bouteilleACopier.QuantiteEnCl;
            CapaciteEnCl = bouteilleACopier.CapaciteEnCl;
        }

        public bool Ouvrir()
        {
            bool ouvertureOK;

            if (EstOuverte)
            {
                ouvertureOK = false;
            }
            else
            {
                this.EstOuverte = true;
                ouvertureOK = true;
            }

            return ouvertureOK;
        }

        public bool Fermer()
        {
            bool fermetureOK;

            if (EstOuverte)
            {
                this.EstOuverte = false;
                fermetureOK = true;
            }
            else
            {
                fermetureOK = false;
            }

            return fermetureOK;
        }

        public bool Vider(double _quantiteEnCl)
        {
            bool vidageOK;

            if (this.EstOuverte
                && _quantiteEnCl > 0
                && this.QuantiteEnCl - _quantiteEnCl >= 0)
            {
                this.QuantiteEnCl -= _quantiteEnCl;
                vidageOK = true;
            }
            else
            {
                vidageOK = false;
            }

            return vidageOK;
        }

        public bool Vider()
        {
            bool vidageOK;

            if (this.EstOuverte && this.QuantiteEnCl > 0)
            {
                this.QuantiteEnCl = 0;
                vidageOK = true;
            }
            else
            {
                vidageOK = false;
            }

            return vidageOK;
        }

        public bool Remplir(double _quantiteEnCl)
        {
            bool remplissageOK;

            if (this.EstOuverte
                && this.QuantiteEnCl + _quantiteEnCl <= this.CapaciteEnCl
                && _quantiteEnCl > 0)
            {
                this.QuantiteEnCl += _quantiteEnCl;
                remplissageOK = true;
            }
            else
            {
                remplissageOK = false;
            }

            return remplissageOK;
        }

        public bool Remplir()
        {
            bool remplissageOK;

            if (this.EstOuverte
                && this.QuantiteEnCl < this.CapaciteEnCl)
            {
                this.QuantiteEnCl = this.CapaciteEnCl;
                remplissageOK = true;
            }
            else
            {
                remplissageOK = false;
            }

            return remplissageOK;
        }

        public override string ToString()
        {
            return "\ncapaciteEnCl : " + this.CapaciteEnCl
                + "\nEstOuverte : " + this.EstOuverte
                + "\nquantiteEnCl : " + this.QuantiteEnCl
                + "\ncontenu : " + this.Contenu;
        }
    }
}
