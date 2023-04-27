VARIABLES

	nbMagasins est un entier
	solde est un réel

TRAITEMENT

	ECRIRE "Saisir le solde"
	LIRE solde

	TANT QUE solde >= 2 ALORS

		nbMagasins <-- nbMagasins + 1
		solde <-- solde / 2 - 1

	FIN TANT QUE

	nbMagasins <-- nbMagasins + 1
	solde <-- 0

AFFICHAGE

	ECRIRE "Barbabé est passé dans " , nbMagasins , " magasins"