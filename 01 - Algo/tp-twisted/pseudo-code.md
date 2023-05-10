VARIABLES

	lancers est un tableau de chaînes de caractères
	de1 est un entier
	de2 est un entier
	de3 est un entier
	totalDes est un entier

	score est un tableau d'entiers
	scoreMax est un entier	
	nbScoreMax est un entier

	nbCouleur est un tableau d'entiers
	nomCouleur est un tableau de chaînes de caractères

	recompense est un réel		

TRAITEMENT

	POUR numlancer de 0 à 20 exclus FAIRE

		POUR numJoueur de 1 à 20 inclus FAIRE

			de1 <-- lancers(numLancer) 0-1
			de2 <-- lancers(numLancer) 2-3
			de3 <-- lancers(numLancer) 4-5

			totalDes <-- de1 + de2 + de3

			SI totalDes <= 6 ALORS
				score(numJoueur - 1) <-- score(numJoueur - 1) + 1
			SINON SI totalDes >= 12 ALORS
				score(numJoueur - 1) <-- score(numJoueur - 1) + 2
			SINON SI totalDes = 3 OU totalDes = 18 ALORS
				score(numJoueur - 1) <-- score(numJoueur - 1) + 3
			FIN SI

			SI de1 = de2 OU de2 = de3 OU de1 = de3 ALORS
				INCREMENTER nbCouleur(RANDOM de |nbCouleur|)
			FIN SI

		FIN POUR

	FIN POUR

	// couleur gagnante

	couleurLogo <-- ""
	couleurMax <-- 0

	POUR i de 0 à 20 exclus FAIRE
		SI nbCouleur(i) > couleurMax ALORS
			couleurMax <-- nbCouleur(i)
			couleurLogo <-- nomCouleur(i)
		FIN SI		
	FIN TANT QUE

	// score max

	scoreMax <-- 0

	POUR joueur de 0 à 20 exclus FAIRE
		SI score(joueur) > scoreMax ALORS
			scoreMax <-- score(joueur)
		FIN SI
	FIN POUR

	// gains de bons d'achat

	nbScoreMax <-- 0

	POUR i de 1 à 20 inclus FAIRE
		SI scoreJoueur(i) = scoreMax ALORS
			INCREMENTER nbScoreMax
		FIN SI
	FIN POUR

	recompense <-- 6 000 / nbScoreMax

AFFICHAGE

	ECRIRE "la couleur la plus populaire" , couleurLogo

	ECRIRE "le meilleur score est " , scoreMax

	POUR i de 0 à 19 exclus
		SI scoreJoueur(i) = scoreMax ALORS
			ECRIRE "joueur " , i , " gagne la partie et remporte" , recompense , 
			" en bons d'achat"
		FIN SI
	FIN POUR
	