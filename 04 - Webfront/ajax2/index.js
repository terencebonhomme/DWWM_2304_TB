async function main() {

    // FUNCTIONS

    function createArticle(trip, img){
        let article = document.createElement('article');
        article.className = 'trip-cont'
        
        let title = document.createElement('h2');
        title.textContent = trip.trip_title.toUpperCase();
        article.appendChild(title);

        let image = document.createElement('img');
        image.src = 'images/' + img;
        article.appendChild(image);

        let description = document.createElement('p');
        description.textContent = trip.trip_description;
        article.appendChild(description);
        
        let contSuite = document.createElement('div');
        contSuite.className = 'cont-suite';

        let btnSuite = document.createElement('div');
        btnSuite.textContent = 'Lire la suite';
        btnSuite.className = 'btn-suite';
        btnSuite.onclick = () => document.location = "#";
        
        contSuite.appendChild(btnSuite);

        article.appendChild(contSuite);

        main.appendChild(article);
    }

    // TRAITEMENT

    // 1. récupérer le json

    const response = await fetch("voyages.json");
    let trips = await response.json();    

    // 2. lister les articles

    let body = document.querySelector('body');

    let main = document.createElement('main');
    main.className = 'trips-cont';

    let images = ['new_york.jpg', 'ryad_park.jpg', 'reunion.jpg', 'tchernobyl.jpg', 'athenes.jpg'];
    
    for (let i = 0; i < trips.length; i++) {
        createArticle(trips[i], images[i]);
    }

    body.appendChild(main);
}

// EXECUTION

main();