VARIABLES

	n est un entier
	isPrime est un booléen

TRAITEMENT

	isPrime <-- vrai

	POUR i de 2 à n / 2 FAIRE

		SI n % 2 = 0 ALORS
			isPrime <-- faux
		FIN SI

	FIN POUR

AFFICHAGE

	SI isPrime = vrai ALORS
		ECRIRE n , " est un nombre premier"
	SINON
		ECRIRE n , " n'est un nombre premier"
	FIN SI
	