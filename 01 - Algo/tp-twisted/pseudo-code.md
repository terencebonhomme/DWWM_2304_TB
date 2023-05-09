VARIABLES

	nombreTour est un entier
	numeroJoueur est tableau d'entiers
	scorejoueur est un tableau d'entiers
	de1 est un entier
	de2 est un entier
	de3 est un entier
	totalDes est un entier
	scoreMax est un entier	
	nbScoreMax est un entier
	nbCouleur est un tableau d'entiers
	nomCouleur est un tableau de chaînes de caractères
	recompenseJoueur est un tableau de réels

TRAITEMENT

	totalDes <-- de1 + de2 + de3

	POUR i de O à 20 exclus FAIRE
		SI totalDes <= 6 ALORS
			scoreJoueur(i) <-- scoreJoueur(i) + 1
		SINON SI totalDes(i) <= 12 ALORS
			scoreJoueur(i) <-- scoreJoueur(i) + 2
		SINON SI totalDes = 3 OU totalDes = 18 ALORS
			scoreJoueur(i) <-- scoreJoueur(i) + 3
		FIN SI

		numeroJoueur(i) <-- i + 1

		SI de1 = de2 OU de2 = de3 OU de1 = de3 ALORS
			INCREMENTER nbCouleur(RANDOM(|nbCouleur|))
		FIN SI
	FIN POUR

	couleurLogo <-- MAX(nbCouleur)

	scoreMax <-- MAX de scoreJoueur

	POUR i de 1 à 20 inclus FAIRE
		SI scoreJoueur(i) = scoreMax ALORS
			INCREMENTER nbScoreMax
		FIN SI
	FIN POUR

	POUR i de O à 20 exclus FAIRE
		SI scoreJoueur(i) = scoreMax ALORS
			recompenseJoueur(i) <-- 6 000 / nbScoreMax
		FIN SI
	FIN POUR

	TRIER scorejoueur par ordre croissant

	POUR i de 0 à 20 exclus
		resultat <-- resultat, " ", scoreJoueur(i)
	FIN POUR

AFFICHAGE

	