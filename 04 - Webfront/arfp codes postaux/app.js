fetch("https://arfp.github.io/tp/web/html-css-js/03-zipcodes/zipcodes.json")
    .then(response => {
        return response.json()
    })
    .then(response => {
        let communes = response;
        let dataListe = document.getElementById('liste-villes');
        let choixVille = document.getElementById('choix-ville');
        let valider = document.getElementById('valider');
        let resultat = document.getElementById('resultat');

        communes.forEach(commune => {
            let option = document.createElement('option');
            option.value = commune.codeCommune;
            option.textContent = commune.nomCommune;
            dataListe.appendChild(option);
        });

        valider.addEventListener('click', () => {
            let selCommune = communes.find((commune) => commune.codeCommune == choixVille.value);
            resultat.innerHTML = 
            `<ul>
            <li>code commune : ${selCommune.codeCommune}</li>
            <li>code postal : ${selCommune.codePostal}</li>
            <li>libelle acheminement : ${selCommune.libelleAcheminement}</li>
            <li>nom commune : ${selCommune.nomCommune}</li>
            </ul>`
        })
    })
    .catch(error => console.log("Erreur : " + error));