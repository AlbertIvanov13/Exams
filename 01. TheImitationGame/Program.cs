
using System.Text;

string encryptedMessage = Console.ReadLine();

string[] commands = Console.ReadLine().Split("|");
StringBuilder word = new StringBuilder(encryptedMessage);

while (commands[0] != "Decode")
{
	if (commands[0] == "Move")
	{
		int numberOfLetters = int.Parse(commands[1]);

		for (int i = 0; i < numberOfLetters; i++)
		{
			word.Append(word[0]);
			word.Remove(0, 1);
		}
	}

	if (commands[0] == "Insert")
	{
		int position = int.Parse(commands[1]);
		string symbol = commands[2];

		word.Insert(position, symbol);
	}

	if (commands[0] == "ChangeAll")
	{
		string element = commands[1];
		string newElement = commands[2];

		for (int i = 0; i < encryptedMessage.Length;i++)
		{
			if (encryptedMessage[i].ToString() == element)
			{
				word.Replace(element, newElement);
			}
		}
	}

	commands = Console.ReadLine().Split("|");
}

Console.WriteLine($"The decrypted message is: {word}");