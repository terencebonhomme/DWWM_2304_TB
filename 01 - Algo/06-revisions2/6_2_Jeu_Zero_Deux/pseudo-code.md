VARIABLES

	nombreJoueur est un entier	
	nombreOrdinateur est un entier	
	scoreJoueur est un entier
	scoreOrdinateur est un entier	

TRAITEMENT

	FAIRE 

		nombreOrdinateur <-- RANDOM

		FAIRE
			ECRIRE "Saisir un nombre : "
			LIRE nombreJoueur
		TANT QUE nombreJoueur < 0 && nombreJoueur > 2

		SI ABS(nombreOrdinateur - nombreJoueur) = 2 ALORS

			SI nombreOrdinateur > nombreJoueur ALORS
				INCREMENTER scoreOrdinateur
			SINON
				INCREMENTER scoreJoueur
			FIN SI

		SINON SI ABS(nombreOrdinateur - nombreJoueur) = 1 ALORS

			SI nombreOrdinateur < nombreJoueur ALORS
				INCREMENTER scoreOrdinateur
			SINON
				INCREMENTER scoreJoueur
			FIN SI

		FIN SI

	TANT QUE nombreJoueur >= 0 && scoreJoueur < 10 && scoreOrdinateur < 10

AFFICHAGE

	SI scoreOrdinateur > scoreJoueur ALORS

		ECRIRE "Ordinateur gagne"
		
	SINON

		ECRIRE "Joueur gagne"

	FIN SI