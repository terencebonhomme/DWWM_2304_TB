VARIABLES

	commande est une chaîne de caractères
	nom est une chaîne de caractères
	prix est un réel
	saisie est un tableau de chaîne de caractères
	nomMoinsCher est un tableau de chaîne de caractères
	prixMoinsCher est un tableau de réels
	quitter est un booléen

TRAITEMENT

	quitter <-- false

	FAIRE

		ECRIRE "Saisir par exemple carottes 2.99, go pour afficher le moins cher, quit pour quitter"

		SI commande = "go" ALORS
					
			ECRIRE "Légume de moins cher au kilo : " , nomMoinsCher

		SINON SI commande = "quit" ALORS

			quitter <-- vrai

		SINON

			saisie <-- séparer à la position de l'espace
			nom <-- saisie[0]
			prix <-- saisie[1]

			ECRIRE "1 kilogramme de " , nom, " coute " , prix , " euros"

			SI prix < prixMoinsCher ALORS
				nomMoinsCher <-- nom
				prixMoinsCher <-- prix
			FIN SI

		FIN SI
		
	TANT QUE quitter = faux
