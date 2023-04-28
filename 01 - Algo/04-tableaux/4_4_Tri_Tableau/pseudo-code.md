VARIABLES

	a est un tableau d'entiers
	i est un entier
	j est un entier
	min est un entier
	indice est intier
	temp est un entier

TRAITEMENT

	POUR i = 0 à N FAIRE 

		min = a[i];

		POUR j = i + 1 à N FAIRE
	
			SI a[i] < min ALORS
				min <-- a[j]
				indice <-- j
			FIN SI

		FIN POUR

		temp <-- a[i]
		a[i] <-- a[indice]
		a[indice] <-- temp

	FIN POUR

