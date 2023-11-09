import { MaDate } from "./MaDate.js";

let inputDate = document.getElementById('date-naissance');
let btnCalculer = document.getElementById('calculer');
let result = document.getElementById('result');

inputDate.setAttribute('max', new Date().toISOString().substring(0, 16));

btnCalculer.addEventListener('click', () => {

    let dateNaissance = new Date(inputDate.value);
    let maDate = new MaDate(dateNaissance);

    if (maDate.estDateFutur()) {
        result.innerHTML = 'Veuillez saisir une date dans le passé !'
    } else {
        let jour = dateNaissance.toLocaleDateString('fr');
        let heure = dateNaissance.toLocaleTimeString('fr');

        result.innerHTML = `<p>Vous êtes né le <span>${jour}</span> à <span>${heure}</span>.</p>`;

        result.innerHTML += `<p>Il s'est écoulé <span>${maDate.deltaAnnees()}</span> année(s) depuis votre naissance.</p>`;

        result.innerHTML += `<p>Votre signe astrologique : <span>${maDate.signeAstro()}<span>`;
    }
})