
using System.Numerics;
using System.Text;

string stops = Console.ReadLine();

string command = Console.ReadLine();

StringBuilder destinations = new StringBuilder(stops);

while (command != "Travel")
{
	string[] tokens = command.Split(":");

	if (tokens[0].Contains("Add"))
	{
		int index = int.Parse(tokens[1]);
		string newStop = tokens[2];

		if (isValidIndex(index, stops.Length))
		{
			destinations.Insert(index, newStop);
		}

	}
	else if (tokens[0].Contains("Remove"))
	{
		int startIndex = int.Parse(tokens[1]);
		int endIndex = int.Parse(tokens[2]);

		if (isValidIndex(startIndex, stops.Length) && isValidIndex(endIndex, stops.Length))
		{
			destinations.Remove(startIndex, endIndex - startIndex + 1);
		}
	}
	else if (tokens[0] == "Switch")
	{
		string oldString = tokens[1];
		string newString = tokens[2];

		if (destinations.ToString().Contains(oldString))
		{
			destinations.Replace(oldString, newString);
		}
	}

    Console.WriteLine(destinations);
	command = Console.ReadLine();
}

Console.WriteLine($"Ready for world tour! Planned stops: {destinations}");

bool isValidIndex(int index, int length)
{
	if (index >= 0 && index <= length)
	{
		return true;
	}
	return false;
}