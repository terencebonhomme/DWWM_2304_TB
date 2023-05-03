VARIABLES

	agePersonnes est un tableau d'entiers
	compteur est un entier
	nombreMoins20 est un entier
	nombrePlus20 est un entier
	nombreEgal20 est un entier

TRAITEMENT

	POUR i de 0 à |agePersonnes| FAIRE

		ECRIRE "Saisir l'âge de la personne ", i + 1
		LIRE agePersonnes[i]

		SI agePersonnes[i] < 20 ALORS
			INCREMENTER nombreMoins20
		SINON SI agePersonnes[i] > 20 ALORS
			INCREMENTER nombrePlus20
		SINON SI agePersonnes[i] = 20 ALORS
			INCREMENTER nombreEgal20
		FIN SI

	FIN POUR	

AFFICHAGE

	SI nombreMoins20 = 20 ALORS
		ECRIRE "TOUTES LES PERSONNES ONT MOINS DE 20 ANS"
	SINON SI nombrePlus20 = 20 ALORS
		ECRIRE "TOUTES LES PERSONNES ONT PLUS DE 20 ANS"
	SINON
		ECRIRE "- de 20 : " , nombreMoins20, " , + de 20 : " , nombrePlus20 , " et = à 20 : " , 
			nombreEgal20
	FIN SI
