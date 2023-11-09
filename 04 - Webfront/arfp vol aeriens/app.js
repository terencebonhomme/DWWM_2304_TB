fetch('https://arfp.github.io/tp/web/html-css-js/04-flights/flights.json')
    .then(response => {
        return response.json()
    })
    .then(response => {
        // VARIABLES

        let tbody = document.querySelector('tbody');
        let inputSearch = document.getElementById('chercher-compagnie');
        let titresColonnes = document.querySelectorAll('#titres-colonnes th');

        let flights = response;        

        let indexTitres = {
            'Flight Id': 'flight_id',
            'Start City': 'start_city',
            'Arrival City': 'arrival_city',
            'Start Time': 'start_time',
            'Arrival Time': 'arrival_time',
            'Flight Duration': 'flight_duration',
            'Airline Name': 'airline_name',
            'Plane Maker': 'plane_maker',
            'Plane Ref': 'plane_ref',
            'Plane Type': 'plane_type',
            'Plane Capacity': 'plane_capacity',
            'Seats Free': 'seats_free',
            'Duration': 'duration'
        }

        // FONCTIONS

        function createCell(tr, prop) {
            let th = tr.insertCell();
            let text = document.createTextNode(prop);
            th.appendChild(text);
        }

        function createRow(flight) {
            let tr = tbody.insertRow();

            for (const prop in flight) {
                createCell(tr, flight[prop]);
            }
        }

        // EVENTS

        // mettre à jour le tableau lors d'une recherche

        inputSearch.addEventListener('input', () => {
            tbody.innerHTML = '';

            flights.forEach(flight => {
                let airlineName = String(flight.airline_name).toLowerCase();

                if (airlineName.startsWith(inputSearch.value.toLowerCase())) {
                    createRow(flight);
                }
            });
        })

        titresColonnes.forEach(titre => {
            titre.addEventListener('click', () => {
                // trier les vols dans le JSON

                if (typeof flights[0][indexTitres[titre.outerText]] == 'number') {
                    flights.sort((a, b) => { return a[indexTitres[titre.outerText]] - b[indexTitres[titre.outerText]] })
                } else {
                    flights.sort((a, b) => {
                        if (a[indexTitres[titre.outerText]] < b[indexTitres[titre.outerText]]) {
                            return -1;
                        } else if (a[indexTitres[titre.outerText]] > b[indexTitres[titre.outerText]]) {
                            return 1;
                        }
                        return 0;
                    })
                }

                // mettre à jour le tableau affiché

                tbody.innerHTML = '';
                flights.forEach(flight => {
                    createRow(flight);
                });
            })
        });

        // TRAITEMENT

        // calculer les durées et les ajouter au JSON

        flights.forEach(flight => {
            let dateStart = new Date(flight.start_time);
            let dateEnd = new Date(flight.arrival_time);

            flight.duration = `${new Date(dateEnd - dateStart).toLocaleTimeString()}`;
        });

        // créer le tableau d'origine

        flights.forEach(flight => {
            createRow(flight);
        });
    })
    .catch(error => console.log('Erreur : ' + error));