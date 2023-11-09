import { MaDate } from "./MaDate.js";

let inputDate = document.getElementById('date-actuelle');
let inputHeure = document.getElementById('heure-actuelle');
let btnAfficherDate = document.getElementById('afficher-date');
let resultatAujourdhui = document.getElementById('resultat-aujourdhui');

let inputDateIntervalle = document.getElementById('date-intervalle');
let btnAfficherDateIntervalle = document.getElementById('afficher-date-intervalle');
let resultatIntervalle = document.getElementById('resultat-intervalle');

btnAfficherDate.addEventListener('click', () => {
    let dateAujourdhui = new Date();

    inputDate.value = dateAujourdhui.toISOString().slice(0, 10);
    inputHeure.value = dateAujourdhui.toLocaleTimeString('fr');

    resultatAujourdhui.innerHTML = `Aujourd'hui nous sommes le <span>${dateAujourdhui.toLocaleDateString('fr')}</span>, l'heure courante est : <span>${inputHeure.value}<span>`;
})

btnAfficherDateIntervalle.addEventListener('click', () => {
    let intervResult = setInterval(() => {
        let dateIntervalle = new Date(inputDateIntervalle.value);
        let maDate = new MaDate(dateIntervalle);
        maDate.dateAujourdhui = new Date();

        let intervalle = maDate.calculerIntervalle();

        if (maDate.dateIntervalle < maDate.dateAujourdhui) {

            resultatIntervalle.innerHTML =
                `Il y a ${intervalle.jours} jours, 
            ${intervalle.heures} heures,
            ${intervalle.minutes} minutes 
            et ${intervalle.secondes} secondes,
            nous étions le ${maDate.dateEnTexte()} 
            à ${maDate.dateIntervalle.toLocaleTimeString()}.`;

        } else {
            resultatIntervalle.innerHTML =
                `Dans ${intervalle.jours} jours, 
            ${intervalle.heures} heures,
            ${intervalle.minutes} minutes
            et ${intervalle.secondes} secondes, 
            nous serons le ${maDate.dateEnTexte()} 
            à ${maDate.dateIntervalle.toLocaleTimeString()}.`;
        }
     }, 1000);
})