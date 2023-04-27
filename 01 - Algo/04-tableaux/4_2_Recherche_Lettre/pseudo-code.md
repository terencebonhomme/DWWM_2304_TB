VARIABLES

	lettre est un caractère
	chaine est une chaine de caractères
	nbOccurences est un entier
	estVide est un booléen

TRAITEMENT

	i <-- 0
	nbOccurences <-- 0

	ECRIRE "Saisir une lettre"
	LIRE lettre

	SI |chaine| = 0 OU chaine[0] = "." ALORS
		ECRIRE "LA CHAINE EST VIDE"
		estVide <-- vrai
	FIN SI

	Si estVide = faux ALORS

		TANT QUE chaine[i] != "." ET i < |chaine| FAIRE
			SI chaine[i] = lettre ALORS
				nbOccurences <-- nbOccurences + 1
			FIN SI	
			i <-- i + 1
		FIN TANT QUE

		ECRIRE nbOcurrences
	FIN SI
	