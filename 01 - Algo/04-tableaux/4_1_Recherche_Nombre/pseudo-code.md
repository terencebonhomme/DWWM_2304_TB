VARIABLES

	exemple est un tableau d'entiers
	n est un entier
	indice est un entier
	trouve est un booléen

TRAITEMENT

	exemple <-- [8, 16, 32, 64, 128, 256, 512]

	ECRIRE "Saisir n"
	LIRE n
	
	POUR i de 0 à |exemple| - 1 FAIRE

		SI n = exemple[i] ALORS
			trouve <-- vrai
			indice <-- i 
		FIN SI

	FIN POUR

AFFICHAGE

	SI trouve = vrai ALORS
		ECRIRE indice
	SINON
		ECRIRE "Nombre non trouvé"
	FIN SI