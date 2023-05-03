VARIABLES

	texte est une chaîne de caractères
	nbConsonnes est un entier
	nbVoyelles est un eniter
	nbChiffres est un entier
	sommeChiffres est un entier
	moyenne est un réel

TRAITEMENT

	POUR i de 0 à |texte| FAIRE

		SI "0123456789" contient texte[i] ALORS
			
			INCREMENTER nbChiffres
			sommeChiffres <-- sommeChiffres + texte[i]

		SINON SI "aeiouy" contient texte[i] ALORS

			INCREMENTER nbVoyelles

		SINON	

			INCREMENTER nbConsonnes

		FIN SI

	FIN POUR

	SI nbChiffres > 0 ALORS

		moyenne <-- sommeChiffres / nbChiffres

	FIN SI

AFFICHAGE

	ECRIRE "Nombre de consonnes : " , nbConsonnes
	ECRIRE "Nombre de voyelles : " , nbVoyelles
	ECRIRE "Nombre de chiffres : " , nbChiffres
	
	SI nbChiffres > 0 ALORS
		ECRIRE "Moyenne : " , moyenne
	FIN SI