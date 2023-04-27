VARIABLES

	a est un entier
	b est un entier
	c est un entier
	tri est une chaîne de caractères

TRAITEMENT

	ECRIRE "Saisir a"
	LIRE a

	ECRIRE "Saisir b"
	LIRE b

	ECRIRE "Saisir c"
	LIRE c

	SI a < b ALORS

		SI b < c ALORS
			
			tri = "a b c"

		SINON

			SI a < c ALORS

				tri = "a c b"

			SINON

				tri = "c a b"

			FIN SI

		FIN SI

	SINON

		SI b < c ALORS
		
			SI a < c ALORS
				
				tri = "b a c"

			SINON

				tri = "b c a"

			FIN SI

		SINON

			tri = "c b a"

		FIN SI

	FIN SI
		
AFFICHAGE

	ECRIRE tri