VARIABLES

	mot est une chaîne de caractères
	motMasque est une chaîne de caractères
	lettre est une chaîne de caractères
	joueurCourant est un entier
	joueurGagnant est un entier
	nbEssai est un entier

TRAITEMENT

	PROGRAMME
	
		FAIRE
			ECRIRE "Saisir un mot : "
			LIRE mot
		TANT QUE |mot| < 5
	
		motMasque <-- masquerMot(mot)
		ECRIRE motMasque

		joueurCourant <-- 1
		joueurGagnant <-- 0
		nbEssai <-- 1

		FAIRE
			ECRIRE "joueur " , joueurCourant , " veuillez saisir une lettre : "
			LIRE lettre

			motMasque <--  revelerLettre(motMasque, lettre)

			ECRIRE motMasque

			SI motMasque != mot ALORS
				SI joueurCourant = 2 ALORS
					INCREMENTER nbEssai
				FIN SI	
			
				changerJoueurCourant(joueurCourant)
			SINON
				joueurGagnant <-- joueurCourant
			FIN SI			
		TANT QUE motMasque != mot ET nbEssai < 6

	FIN PROGRAMME

	chaîne de caractères FONCTION revelerLettre(VAL chaîne de caractère mot, chaîne de caractères motMasque, 
	caractère lettre)
		motRevele est une chaîne de caractères

		motRevele <-- mot
		
		SI mot(0) = lettre ALORS
			motRevele(0) <-- lettre
		SINON SI mot(|mot| - 1) = lettre ALORS
			motRevele(|mot| - 1) <-- lettre
		FIN SI

		RETOURNER motRevele
	FIN FONCTION

	chaîne de caractères FONCTION masquerMot(VAL chaîne de caractères mot)
		RETOURNER "-" , mot--1-(|mot| - 2) , "-"
	FIN FONCTION

	entier FONCTION changerJoueurCourant(VAL chaîne de caractères joueurCourant)
		tour est un entier

		SI joueurCourant = 1 ALORS
			tour <-- 2
		SINON
			tour <-- 1
		FIN SI

		RETOURNER tour
	FIN FONCtioN

AFFICHAGE
	
	ECRIRE joueurGagnant , " a gagné"