
using System.Text.RegularExpressions;

string input = Console.ReadLine();

string pattern = @"([=\/])(?<destination>[A-Z][A-Za-z]{2,})\1";

MatchCollection matches = Regex.Matches(input, pattern);

List<string> destinations = new List<string>();

int travelPoints = 0;

foreach (Match match in matches)
{
	destinations.Add(match.Groups["destination"].Value);
	travelPoints += match.Groups["destination"].Value.Length;
}

Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
Console.WriteLine($"Travel Points: {travelPoints}");