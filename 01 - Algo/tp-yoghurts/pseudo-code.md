VARIABLES

	nbVotes est un entier
	couleur est une chaîne de caractères
	nbRouge est un entier
	nbJaune est un entier
	nbBleu est un entier
	premierRouge est un entier
	premierJaune est un entier
	premierBleu est un entier
	conclusion est une chaîne de caractères

TRAITEMENT

	premierRouge <-- -1
	premierJaune <-- -1
	premierBleu <-- -1

	i <-- 0
	TANT QUE (premierRouge = -1 OU premierJaune = -1 OU premierBleu = -1) ET i < nbVotes FAIRE

		SI votes[i] = "rouge" ALORS
			premierRouge <-- i
		SINON SI votes[i] = "jaune" ALORS
			premierJaune <-- i
		SINON SI votes[i] = "bleu" ALORS
			premierBleu <-- i
		FIN SI
		
		INCREMENTER i

	FIN QUE

	POUR i de 0 à nbVotes exclus FAIRE

		SI votes[i] = "rouge" ALORS
			INCREMENTER nbRouge
		SINON SI votes[i] = "jaune" ALORS
			INCREMENTER nbJaune
		SINON SI votes[i] = "bleu" ALORS
			INCREMENTER nbBleu
		FIN SI

	FIN POUR

	SI R < J ALORS
		SI R < B ALORS
			ECRIRE nbJaune , " " , nbBleu
		SINON
			ECRIRE nbJaune , " " , nbRouge
		FIN SI
	SINON SI J < B ALORS
		SI J < R ALORS
			ECRIRE nbBleu , " " , nbRouge
		SINON
			ECRIRE nbBleu , " " , nbJaune
		FIN SI
	SINON SI J < R ALORS
		SI J < B ALORS
			ECRIRE nbRouge , " " , nbBleu
		SINON
			ECRIRE nbRouge , " " , nbJaune
		FIN SI
	SI R = J < B ALORS
		SI premierrouge < premierJaune ALORS
			ECRIRE nbBleu , " " , nbJaune
		SINON
			ECRIRE nbBleu , " " , nbRouge
		FIN SI
	SI R = B < J ALORS
		SI premierRouge < premierBleu ALORS
			ECRIRE nbJaune , " " , nbBleu
		SINON
			ECRIRE nbJaune , " " , nbRouge
		FIN SI
	SI J = B < R ALORS
		Si premierJaune < premierBleu ALORS
			ECRIRE nbRouge , " " , nbBleu
		SINON
			ECRIRE nbRouge , " " , nbJaune
		FIN SI
	SI R < J = B ALORS
		SI premierBleu < premierJaune ALORS
			ECRIRE nbJaune , " ", nbBleu
		SINON
			ECRIRE nbBleu , " " , nbJaune
		FIN SI
	SI J < R = B ALORS
		SI premierBleu < premierRouge ALORS
			ECRIRE nbRouge , " " , nbBleu
		SINON
			ECRIRE nbBleu , " " , nbRouge
		FIN SI
	SI B < R = J ALORS
		SI premierJaune < premierRouge ALORS
			ECRIRE nbRouge , " " , nbJaune
		SINON
			ECRIRE nbJaune , " " , nbRouge
		FIN SI
	SI R = J = B ALORS		
		SI premierRouge < premierJaune ALORS
			// b r j
			SI premierBleu < premierRouge ALORS
				ECRIRE "jaune rouge"
			SINON
				//r b j 
				SI premierBleu < premierJaune ALORS
					ECRIRE "jaune bleu"
				// r j b
				SINON
					ECRIRE "bleu jaune"
				FIN SI
			FIN SI
		SINON
			// b j r
			SI premierBleu < premierJaune ALORS
				ECRIRE "rouge jaune"
			SINON
				// j b r
				SI premierRouge < premierBleu ALORS
					ECRIRE "rouge bleu"
				// j r b
				SINON
					ECRIRE "bleu rouge"
				FIN SI
			FIN SI
		FIN SI
	FIN SI

AFFICHAGE
