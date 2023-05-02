VARIABLES

	temperature est une chaîne de caractères
	valeur est un réel
	unite est une chaîne de caractères
	resultat est un réel

TRAITEMENT

	FAIRE

		ECRIRE "Saisir une température suivie de l'unité C/F (exemple 32 C)"
		LIRE temperature

		valeur <-- CONVERTIR en réel (temperature de 0 à positionEspace - 1)
		unite <-- temperature de positionEspace + 1 à |temperature|

	TANT QUE valeur < -459.67 OU valeur > 5 000 000

	SI unite = "F" ALORS
		resultat <-- (valeur - 32) * 5 / 9
	SINON SI unite = "C" ALORS
		resultat <-- (valeur * 9 / 5) + 32
	FIN SI

AFFICHAGE

	ECRIRE résultat

	