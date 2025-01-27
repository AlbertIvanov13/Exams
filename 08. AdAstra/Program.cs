
using System.Text.RegularExpressions;

string input = Console.ReadLine();

string pattern = @"([#|])(?<food>[A-Za-z ]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d+)\1";

MatchCollection matches = Regex.Matches(input, pattern);

List<string> foods = new List<string>();

int calories = 0;

foreach (Match item in matches)
{
	calories += int.Parse(item.Groups["calories"].Value);
}

int days = calories / 2000;

Console.WriteLine($"You have food to last you for: {days} days!");

foreach (Match item in matches)
{
    Console.WriteLine($"Item: {item.Groups["food"].Value}, Best before: {item.Groups["date"].Value}, Nutrition: {item.Groups["calories"].Value}");
}