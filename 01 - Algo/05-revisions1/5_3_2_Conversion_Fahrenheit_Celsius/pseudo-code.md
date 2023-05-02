VARIABLES

	unite est une chaîne de caractères
	commande est une chaîne de caractères
	minimum est un réel
	maximum est un réel	

TRAITEMENT

	FAIRE
		
		ECRIRE "Saisir une unité de mesure (C ou F) : "
		LIRE commande

		SI commande != "quit" ALORS

			unite <-- commande

			ECRIRE "Saisir le minimum de la plage de valeurs  : "
			LIRE minimum

			ECRIRE "Saisir le maximum de la plage de valeurs : "
			LIRE maximum

			SI unite = "F" ALORS
				minimum <-- (minimum - 32) * 5 / 9
				maximum <-- (maximum - 32) * 5 / 9
			SINON SI unite = "C" ALORS
				minimum <-- (minimum * 9 / 5) + 32
				maximum <-- (maximum * 9 / 5) + 32
			FIN SI

			ECRIRE "[" , minimum , ";" , maximum, "]"

		FIN SI

	TANT QUE commande != "quit"	
	