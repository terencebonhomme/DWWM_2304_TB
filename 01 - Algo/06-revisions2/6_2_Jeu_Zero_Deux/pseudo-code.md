VARIABLES

	nombreJoueur est un entier	
	nombreOrdinateur est un entier	
	scoreJoueur est un entier
	scoreOrdinateur est un entier	

TRAITEMENT

	

	FAIRE 

		nombreOrdinateur <-- RANDOM

		ECRIRE "Saisir un nombre : "
		LIRE nombreJoueur

		SI ABS(nombreOrdinateur - nombreJoueur) = 2 ALORS

			SI nombreOrdinateur > nombreJoueur ALORS
				scoreOrdinateur <-- scoreOrdinateur + 2
			SINON
				scoreJoueur <-- scoreJoueur + 2
			FIN SI

		SINON SI ABS(nombreOrdinateur - nombreJoueur) = 1 ALORS

			SI nombreOrdinateur > nombreJoueur ALORS
				scoreOrdinateur <-- scoreOrdinateur + 2
			SINON
				scoreJoueur <-- scoreJoueur + 2
			FIN SI

		FIN SI

	TANT QUE nombreJoueur >= 0 && scoreJoueur < 10 && scoreOrdinateur < 10

AFFICHAGE

	SI scoreOrdinateur > scoreJoueur ALORS
		
	SINON

	FIN SI