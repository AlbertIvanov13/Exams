
using System.Numerics;
using System.Text;

string stops = Console.ReadLine();

string command = Console.ReadLine();

StringBuilder destinations = new StringBuilder(stops);

while (command != "Travel")
{
	string[] tokens = command.Split("|");

	if (tokens[0].Contains("Add"))
	{
		int index = int.Parse(tokens[1]);
		string newStop = tokens[2];

		if (isValidIndex(index, stops.Length))
		{

		}

		destinations.Insert(index, newStop);
	}
	else if ()
	{

	}

	command = Console.ReadLine();
}

bool isValidIndex(int index, int length)
{
	if (index > 0 && index <= length)
	{
		return true;
	}
	return false;
}