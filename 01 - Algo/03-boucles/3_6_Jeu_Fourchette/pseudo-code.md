VARIABLES

	nombreChoisi est un entier
	n est un entier
	min est un entier
	max est un entier
	nbEssais est un entier

TRAITEMENT

	n <-- RANDOM(0,100)

	ECRIRE "Saisir un nombre"
	LIRE nombreChoisi

	FAIRE
		nbEssais <-- nbEssais + 1

		SI nombreChoisi < n ALORS
			min <-- nombreChoisi
		SINON SI nombreChoisi > n
			max <-- nombreChoisi			
		FIN SI

		SI nombreChoisi != n ALORS
			ECRIRE min , " - " , max
		FIN SI

	TANT QUE nombreChoisi != n FIN TANT QUE

AFFICHAGE

	ECRIRE "Bravo vous avez trouvé en " , nbEssais , " essais"
