namespace Voiture
{
    public class Moteur
    {
        bool enMarche;

        public bool EnMarche { get => enMarche; }

        public Moteur()
        {
            this.enMarche = false;
        }
        public Moteur(bool enMarche)
        {            
            this.enMarche = enMarche;
        }

        public Moteur(Moteur moteurACopier)
        {
            this.enMarche = moteurACopier.EnMarche;
        }

        public bool Demarrer()
        {
            bool demarrageOK;

            if (!this.enMarche)
            {
                this.enMarche = true;
                demarrageOK = true;
            }
            else
            {
                demarrageOK = false;
            }         

            return demarrageOK;
        }

        public bool EntrainerRoues(Roue roue1, Roue roue2)
        {
            bool entrainementRouesOK;

            entrainementRouesOK = roue1.Tourner() && roue2.Tourner();

            return entrainementRouesOK;
        }

        public bool ArreterRoues(Roue roue1, Roue roue2)
        {
            bool arretRouesOK;

            arretRouesOK = roue1.Stopper() && roue2.Stopper();

            return arretRouesOK;
        }

        public bool Eteindre()
        {
            bool extinctionOK;

            if (this.enMarche)
            {
                this.enMarche = false;
                extinctionOK = true;
            }
            else
            {
                extinctionOK = false;
            }

            return extinctionOK;
        }
    }
}
