namespace Voiture
{
    public class Voiture
    {
        string? marque;
        Moteur sonMoteur;
        List<Roue> ses4Roues;

        public Moteur SonMoteur { get => sonMoteur; }
        public List<Roue> Ses4Roues { get => ses4Roues; }

        public Voiture()
        {
            this.sonMoteur = new Moteur();
            this.ses4Roues = new List<Roue>() { 
                new(), 
                new(), 
                new(), 
                new() 
            };
        }

        public bool Demarrer()
        {
            bool demarrageOK;

            demarrageOK = sonMoteur.Demarrer();            

            return demarrageOK;
        }

        public bool CouperContact()
        {
            bool coupureContactOK;

            coupureContactOK = this.sonMoteur.Eteindre();           

            return coupureContactOK;
        }

        public bool Avancer()
        {
            bool avancementOK;
            Roue roue1;
            Roue roue2;

            roue1 = this.ses4Roues.ElementAt(0);
            roue2 = this.ses4Roues.ElementAt(1);

            if (this.sonMoteur.EnMarche)
            {
                avancementOK = this.sonMoteur.EntrainerRoues(roue1, roue2);
            }
            else
            {
                avancementOK = false;
            }

            return avancementOK;
        }

        public bool Freiner()
        {
            bool freinageOK;
            Roue roue1;
            Roue roue2;

            roue1 = this.ses4Roues.ElementAt(0);
            roue2 = this.ses4Roues.ElementAt(1);

            if (this.sonMoteur.EnMarche)
            {
                freinageOK = this.sonMoteur.ArreterRoues(roue1, roue2);
            }
            else
            {
                freinageOK = false;
            }

            return freinageOK;
        }
    }
}
