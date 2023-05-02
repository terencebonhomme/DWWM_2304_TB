VARIABLES

	sens est une chaîne de caractères
	valeur est un réel
	resultat est un réel

TRAITEMENT

	ECRIRE "Saisir le sens de conversion (km ou mi) : "
	LIRE sens

	ECRIRE "Saisir une valeur : "
	LIRE valeur

	SI sens = "mi" ALORS
		resultat <-- valeur / 1.609
	SINON SI sens = "km" OU sens = "" ALORS
		resultat <-- valeur * 1.609		
	FIN SI

AFFICHAGE

	ECRIRE resultat , " " , sens