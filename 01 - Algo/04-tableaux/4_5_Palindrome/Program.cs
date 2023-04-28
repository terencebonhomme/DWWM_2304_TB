string input;
string result;
bool isPalindrome;
int demiLength;

isPalindrome = true;

do
{
    Console.Write("Saisir une chaîne de caractères : ");
    input = Console.ReadLine().Replace(" ", "");

    demiLength = (int) Math.Floor((input.Length / 2D) - 1);

    for (int i = 0; i < demiLength && isPalindrome; i++)
    {
        if (input[i] != input[input.Length - 2 - i])
        {
            isPalindrome = false;
        }
    }
} while (input == "." || input.Length > 0 && input[input.Length - 1] != '.');

/*if (input.Length == 0)
{
    result = "la phrase est vide";
}
else */
if (isPalindrome)
{
    result = "la chaîne de caractères est un palindrome";
}
else
{
    result = "la chaîne de caractères n’est pas un palindrome";
}

// AFFICHAGE

Console.WriteLine(result);

// FIN DU PROGRAMME

Console.ReadLine();
