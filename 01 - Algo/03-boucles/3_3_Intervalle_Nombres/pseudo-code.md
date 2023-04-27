VARIABLES

	a est un entier
	b est un entier
	resultat est une chaîne de caractères

TRAITEMENT

	ECRIRE "Saisir a"
	LIRE a

	ECRIRE "Saisir b"
	LIRE b

	resultat <-- "" + a

	POUR i de a à b FAIRE
		resultat <-- resultat, " " ; i
	FIN POUR

AFFICHAGE