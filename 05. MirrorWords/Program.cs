

using System.Text.RegularExpressions;

string text = Console.ReadLine();

string pattern = @"([\@\#])(?<firstWord>[A-Za-z]{3,})\1\1(?<secondWord>[A-Za-z]{3,})\1";

MatchCollection matches = Regex.Matches(text, pattern);

List<string> mirrorWords = new List<string>();

foreach (Match match in matches)
{
	if (match.Groups["firstWord"].Value.Length == match.Groups["secondWord"].Value.Length)
	{
		char[] newArray = match.Groups["secondWord"].Value.ToArray();
		Array.Reverse(newArray);
		string reversedString = new string(newArray);
		if (match.Groups["firstWord"].Value == reversedString)
		{
			mirrorWords.Add($"{match.Groups["firstWord"].Value} <=> {match.Groups["secondWord"].Value}");
		}
	}
}


if (matches.Count == 0)
{
    Console.WriteLine($"No word pairs found!");
}
else if (matches.Count > 0)
{
    Console.WriteLine($"{matches.Count} word pairs found!");
}

if (mirrorWords.Count == 0)
{
    Console.WriteLine($"No mirror words!");
}
else if (mirrorWords.Count > 0)
{
    Console.WriteLine($"The mirror words are: ");
    Console.WriteLine(string.Join(", ", mirrorWords));
}