VARIABLES

	scoreJoueur est un tableau d'entiers
	de1 est un entier
	de2 est un entier
	somme2Des est un entier
	numJoueur est un entier
	resultats est un tableau de chaînes de caractères
	ngTour est un entier

TRAITEMENT

	nbtour <-- donnée par l'API	

	// calcul des points

	POUR tour de 0 à nbtour FAIRE

		numJoueur <-- donnée par l'API
		de1 <-- donnée par l'API
		de2 <-- donnée par l'API

		somme2Des <-- de1 + de2
		
		SI de1 = de2 ALORS

			SI scoreJoueur[numJoueur] >= 2 ALORS
				scoreJoueur[numJoueur] <-- scoreJoueur[numJoueur] - 2
			FIN SI

		SINON SI somme2Des inférieur à 6 ALORS

			scoreJoueurs[numJoueur] <-- 0

		SINON SI somme2Des entre 6 et 10 ALORS

			scoreJoueurs[numJoueur] <-- 1

		SINON SI somme2Des supérieur à 10 ALORS

			scoreJoueurs[numJoueur] <-- 3

		FIN SI				

	FIN POUR	

AFFICHAGE

	ECRIRE scoreJoueurs[0] , "/" , scoreJoueurs[1] , "/" , scoreJoueurs[2]
