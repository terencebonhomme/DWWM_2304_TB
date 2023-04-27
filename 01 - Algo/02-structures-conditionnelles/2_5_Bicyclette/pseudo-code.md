VARIABLES
	
	beauTemps est un booléen
	bicycletteParfaitEtat est un booléen
	reparationsImmediates est un booléen
	GoTDansSalon est un booléen
	GotDansBibliothèque est un booléen
	action est une chaîne de caractères

TRAITEMENT

	ECRIRE "Fera t'il beau ?"
	LIRE beauTemps

	SI beauTemps = vrai ALORS

		ECRIRE "J'irai faire une balade."

		ECRIRE "Le vélo sera t'il en parfait état ?"
		LIRE bicycletteParfaitEtat

		SI bicycletteParfaitEtat ALORS

			action = "Je ferai une balade à bicyclette."

		SINON

			ECRIRE "Je ferai réparer mon vélo."

			ECRIRE "Les réparations seront-elles immédiates ?"
			LIRE reparationsImmediates

			SI reparationsImmediates ALORS
				action = "Je ferai une balade à bicyclette."
			SINON
				action = "J'irai à pied jusqu'à l'étang pour ceuillir les joncs."
			FIN SI

		FIN SI

	ELSE
		
		ECRIRE "J'irai lire un livre."

		ECRIRE "Le tome de Game of Thrones ne sera pas dans le salon ?"
		LIRE GoTDansSalon

		SI GoTDansSalon ALORS

			action <-- "Je lirai le tome de Game of Thrones du salon dans mon fauteuil."

		SINON

			ECRIRE "J'irai à la bibliothèque."

			ECRIRE "Le tome de Game of Thrones sera à la bibliothèque ?"
			LIRE GoTDansBibliotheque

			SI GoTDansBibliotheque ALORS
				action <-- "Je lirai le tome de Game of Thrones de la bibliothèque dans mon fauteuil."
			ELSE
				action <-- "Je lirai un roman policier dans mon fauteuil."
			FIN SI

		FIN SI

	FIN SI

AFFICHAGE

	ECRIRE action	