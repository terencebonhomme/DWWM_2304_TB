VARIABLES

	age est un entier
	compteur est en entier

TRAITEMENT

	compteur <-- 0

	POUR i de 1 à 20 FAIRE

		ECRIRE "Saisir la valeur " , i , " : "
		LIRE age

		SI age < 20 ALORS
			INCREMENTER compteur
		FIN SI

	FIN POUR

AFFICHAGE

	ECRIRE compteur