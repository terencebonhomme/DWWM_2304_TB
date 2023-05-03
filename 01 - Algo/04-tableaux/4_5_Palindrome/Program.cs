string input;
string result;
bool isPalindrome;
int demiLength;
int i;

isPalindrome = true;

do
{
    Console.Write("Saisir une chaîne de caractères : ");
    input = Console.ReadLine().Replace(" ", "");

    demiLength = (int) Math.Floor((input.Length / 2D) - 1);

    i = 0;
    while(isPalindrome && i < demiLength)
    {
        if (input[i] != input[input.Length - 2 - i])
        {
            isPalindrome = false;
        }

        i++;
    }
} while (input == "." || input.Length > 0 && input[input.Length - 1] != '.');

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
