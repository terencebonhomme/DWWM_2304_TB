async function main() {

    // FUNCTIONS

    function createCardsTable() {

        // créer un tableau des valeurs

        let body = document.getElementsByTagName('body')[0];
        let table = document.createElement('table');

        // titres du tableau

        let thead = document.createElement('thead');

        let trHead = document.createElement('tr');

        // for (const key in cardgame[0]) {
            // if (key != 'description') {
        let props = ['id', 'name', 'level', 'description', 'power', 'attack', 'armor', 'damage', 'mitigation', 'played', 'victory', 'defeat', 'draw'];
        props.forEach(prop => {
            let th = document.createElement('th');
            // th.textContent = key;
            th.textContent = prop;
            trHead.appendChild(th);
        //}
            // }
        })

        thead.appendChild(trHead);
        table.appendChild(thead);

        // données du tableau

        let tbody = document.createElement('tbody');

        // let props = ['id', 'name', 'level', 'description', 'power', 'attack', 'armor', 'damage', 'mitigation', 'played', 'victory', 'defeat', 'draw'];

        for (const ele of cardgame) {
            let trBody = document.createElement('tr');
            props.forEach(prop => {
                let td = document.createElement('td');
                // td.textContent = value;
                td.textContent = ele[prop];

                trBody.appendChild(td);
            });
            //for (const [key, value] of Object.entries(ele)) {
                
            //}
            tbody.appendChild(trBody);
        }

        table.appendChild(tbody);
        body.appendChild(table);
    }

    function getBest(value) {
        let b = cardgame.sort(function (a, b) { return b[value] - a[value]; })[0]
        return b;
    }

    function createCard(prop) {
        let body = document.getElementsByTagName('body')[0];

        let cardBestAttack = getBest(prop);

        let cardCont = document.createElement('main');
        cardCont.classList.add('card-cont');

        let cardLevel = document.createElement('div');
        cardLevel.classList.add('card-level');
        cardLevel.innerText = cardBestAttack.level;
        cardCont.appendChild(cardLevel);

        let cardInfo = document.createElement('div');
        cardInfo.classList.add('card-info');

        let cardName = document.createElement('div');
        cardName.classList.add('card-name');
        cardName.innerText = cardBestAttack.name;
        cardInfo.appendChild(cardName);

        let cardHistory = document.createElement('div');
        cardHistory.classList.add('card-history');
        cardHistory.innerText = "Played : " + cardBestAttack.played + " | Victories : " + cardBestAttack.victory;
        cardInfo.appendChild(cardHistory);

        cardCont.appendChild(cardInfo);

        let cardImage = document.createElement('div');
        cardImage.classList.add('card-img');

        let image = document.createElement('img');
        image.src = 'knight.png'
        cardImage.appendChild(image);

        cardCont.appendChild(cardImage);

        let cardPower = document.createElement('div');

        let cardPowerLib = document.createElement('div');
        cardPowerLib.classList.add('card-power-lib');
        cardPowerLib.innerText = 'Power';
        cardPower.appendChild(cardPowerLib);

        let cardPowerStat = document.createElement('div');
        cardPowerStat.classList.add('card-power-stat');
        cardPowerStat.innerText = cardBestAttack.power;
        cardPower.appendChild(cardPowerStat);

        cardCont.appendChild(cardPower);

        let cardAttack = document.createElement('div');

        let cardAttackLib = document.createElement('div');
        cardAttackLib.classList.add('card-attack-lib');
        cardAttackLib.innerText = 'Attack';
        cardAttack.appendChild(cardAttackLib);

        let cardAttackStat = document.createElement('div');
        cardAttackStat.classList.add('card-attack-stat');
        cardAttackStat.innerText = cardBestAttack.attack;
        cardAttack.appendChild(cardAttackStat);

        cardCont.appendChild(cardAttack);

        let cardDefense = document.createElement('div');

        let cardDefenseLib = document.createElement('div');
        cardDefenseLib.classList.add('card-defense-lib');
        cardDefenseLib.innerText = 'Defense';
        cardDefense.appendChild(cardDefenseLib);

        let cardDefenseStat = document.createElement('div');
        cardDefenseStat.classList.add('card-defense-stat');
        cardDefenseStat.innerText = cardBestAttack.armor;
        cardDefense.appendChild(cardDefenseStat);

        cardCont.appendChild(cardDefense);

        body.appendChild(cardCont);
    }

    // TRAITEMENT

    // 1. récupérer le json

    const response = await fetch("https://arfp.github.io/tp/web/html-css-js/02-cardgame/cardgame.json");
    let cardgame = await response.json();

    // cardgame.forEach(element => {
    //     if (element['description'] == null) {
    //         element['description'] = '';
    //     } else {
    //         let text = element['description'];
    //         delete element.description;
    //         element['description'] = text;
    //     }
    // });

    // 2. tableau des cartes

    createCardsTable();

    // 3. meilleures cartes

    // afficher la carte avec le plus de puissance d'attaque

    createCard('attack');

    // afficher la carte avec le plus d'armure

    createCard('armor');

    // afficher la carte avec le plus de parties jouées

    createCard('played');

    // afficher la carte avec le plus grand nombre de victoires

    createCard('victory');
}

// EXECUTION

main();