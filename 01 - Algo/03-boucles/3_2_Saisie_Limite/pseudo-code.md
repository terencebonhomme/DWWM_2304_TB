VARIABLES

	saisie est une chaîne de caractères
	password est une chaîne de caractères
	nbEssai est un entier
	maxEssai est un entier

TRAITEMENT

	password <-- "formation"

	FAIRE

		ECRIRE "Saisir le mot de passe"
		LIRE saisie

	TANT QUE saisie != password || nbEssai < maxEssai


	SI saisie = password ALORS

		ECRIRE "Vous êtes connecté"

	SINON

		ECRIRE "Votre compte est bloqué"

	FIN SI

AFFICHAGE

