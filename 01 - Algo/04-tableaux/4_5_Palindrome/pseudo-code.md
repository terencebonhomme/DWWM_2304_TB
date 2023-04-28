VARIABLES

	saisie est une chaîne de caractères
	estPalindrome est un booléen
	resultat est une chaîne de caractères
	i est un entier

TRAITEMENT

	estPalindrome <-- vrai

	FAIRE

		ECRIRE "Saisir une chaîne de caractères"
		LIRE saisie	

		SI |saisie| = 0 ALORS

			resultat <-- "la phrase est vide"

		SINON

			POUR i = 0 à |saisie| - 1 FAIRE

				SI saisie[i] != saisie[|saisie| - 2 - i] ALORS
					estPalindrome <-- faux
				FIN SI

			FIN POUR	
			
		FIN SI		

	TANT QUE saisie == "." OU saisie[|saisie| - 1] != "."

	SI estPalindrome = vrai ALORS

		resultat <-- "la chaîne de caractères est un palindrome"

	SINON

		resultat <-- "la chaîne de caractères n’est pas un palindrome"

	FIN SI

// AFFICHAGE

	ECRIRE resultat
	