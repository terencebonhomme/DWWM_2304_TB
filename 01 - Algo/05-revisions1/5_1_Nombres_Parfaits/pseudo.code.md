VARIABLES

	somme est un entier
	compteur est un entier
	nombre est en entier
	nombreParfaits est un tableau d'entiers

TRAITEMENT

	counter <-- 0
	nombre <-- 2

	TANT QUE compteur < 4 
		
		somme <-- 0

		POUR i de 1 à nombre FAIRE
			
			SI nombre mod i = 0 ALORS

				somme <-- somme + i

			FIN SI

		FIN

		SI somme = nombre ALORS			
			nombresParfaits[compteur] <-- nombre
			INCREMENTER compteur
		FIN SI

		INCREMENTER nombre

	FIN TANT QUE	

AFFICHAGE

	ECRIRE "Affichage des 4 premiers nombres parfaits : "

	POUR i de 0 à N FAIRE
		ECRIRE nombresParfaits[i] , " est un nombre parfait."
	FIN POUR
