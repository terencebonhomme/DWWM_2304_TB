VARIABLES

    a est un entier
    ageRetraite est un entier
    estRetraite est un booléen

TRAITEMENT

    LIRE a

    SI a >= ageRetraite ALORS

      ECRIRE "Etes-vous à la retraite ?"
      LIRE "estRetraite"  
      
      SI retraite = vrai ALORS
        ECRIRE "Vous êtes à la retraite depuis " ; a - ageRetraite , " années"
      SINON
        ECRIRE "C’est le moment de prendre sa retraite."
      FIN SI
      
    SINON SI a < aRetraite ALORS

      ECRIRE "Il vous reste ", ageRetraite - a ; " années avant la retraite."

    SINON

      "La valeur fournie n’est pas un âge valide."

    FIN SI

FIN PROGRAMME