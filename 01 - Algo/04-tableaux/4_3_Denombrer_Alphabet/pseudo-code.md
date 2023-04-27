VARIABLES

	texte est une chaîne de caractères
	lettre est un entier;

TRAITEMENT

	POUR i de 0 à |texte| - 1 FAIRE
		
		POUR lettre de entier de 'a' à entier de 'z' FAIRE

			compteur <-- 0

			SI texte[i] = lettre ALORS

				compteur <-- compteur + 1
				
			FIN SI

			ECRIRE lettre , " : " , counter

		FIN POUR

	FIN POUR

AFFICHAGE