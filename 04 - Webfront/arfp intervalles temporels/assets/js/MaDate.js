class MaDate {
    /**
     * Constructeur
     * @param {Date} _date 
     */
    constructor(_date) {
        this.dateAujourdhui = new Date();
        this.dateIntervalle = _date;
    }

    /**
     * Calculer le temps entre la date d'aujourd'hui et la date pour l'intervalle
     * @returns 
     */
    calculerIntervalle() {
        let intervalle = {};
        let diffDates = this.dateAujourdhui - this.dateIntervalle;

        intervalle.secondes = parseInt(Math.abs((diffDates / (1000)) % 60));
        intervalle.minutes = parseInt(Math.abs((diffDates / (1000 * 60)) % 60));
        intervalle.heures = parseInt(Math.abs((diffDates / (1000 * 60 * 60)) % 24));
        intervalle.jours = parseInt(Math.abs((diffDates / (1000 * 60 * 60 * 24))));

        return intervalle;
    }

    dateEnTexte() {
        let jour = this.dateIntervalle.getDate();
        let mois = this.dateIntervalle.getMonth();
        let annee = this.dateIntervalle.getFullYear();

        let listeMois = ['janvier', 'février', 'mars', 'avril', 'mai', 'juin', 'juillet', 'août', 'septembre', 'octobre', 'novembre', 'décembre'];

        return `${jour} ${listeMois[mois]} ${annee}`;
    }
}

export { MaDate };