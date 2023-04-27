VARIABLES

	prenom est une chaîne de caractères
	nbEssai est un entier
	maxEssai est un entier

TRAITEMENT

	nbEssai <-- 0
	maxEssai <-- nbEssai

	FAIRE

		ECRIRE "Saisir votre prenom"
		LIRE prenom
		nbEssai <-- nbEssai + 1

	TANT QUE |prenom| < 2 || nbEssai < maxEssai

AFFICHAGE

	SI nbEssai < maxEssai  
	ECRIRE "Bonjour " , prenom