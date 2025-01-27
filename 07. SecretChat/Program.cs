
using System.Text;

string concealedMessage = Console.ReadLine();

StringBuilder message = new StringBuilder(concealedMessage);

string command = Console.ReadLine();

while (command != "Reveal")
{
	string[] instructions = command.Split(":|:");

	if (instructions[0] == "InsertSpace")
	{
		int index = int.Parse(instructions[1]);

		message.Insert(index, " ");
        Console.WriteLine(message);
	}
	else if (instructions[0] == "Reverse")
	{
		string substring = instructions[1];
		if (message.ToString().Contains(substring))
		{
			char[] newArray = substring.ToCharArray();
			Array.Reverse(newArray);
			string reversedSubstring = new string(newArray);
			int index = message.ToString().IndexOf(substring);
			message.Remove(index, reversedSubstring.Length);
			message.Append(reversedSubstring);
            Console.WriteLine(message);
		}
		else
		{
            Console.WriteLine("error");
		}
	}
	else if (instructions[0] == "ChangeAll")
	{
		string substring = instructions[1];
		string replacement = instructions[2];

		message.Replace(substring, replacement);
        Console.WriteLine(message);
	}


	command = Console.ReadLine();
}

Console.WriteLine($"You have a new text message: {message}");