VARIABLES

	a est un entier
	conclusion est une chaîne de caractères

TRAITEMENT

	LIRE a

	SI a >= 18 ALORS
	  conclusion <-- "Vous êtes majeur"
	SINON SI a < 0
	  conclusion <-- "Vous n’êtes pas encore né"
	SINON
	  conclusion <-- "Vous êtes mineur"
	FIN SI

CONCLUSION
	
	ECRIRE conclusion

FIN PROGRAMME