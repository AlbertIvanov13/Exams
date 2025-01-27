using System.Reflection.Metadata.Ecma335;

namespace _06._ThePianist
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int piecesNumber = int.Parse(Console.ReadLine());

			Dictionary<string, Piece> dictionary= new Dictionary<string, Piece>();

			bool isRemoved = false;

			var newDictionary = new Dictionary<string, Piece>();

			for (int i = 0; i < piecesNumber; i++)
			{
				string[] input = Console.ReadLine().Split("|");
				string pieceName = input[0];
				string composer = input[1];
				string key = input[2];
				Piece piece = new Piece();
				piece.Composer = composer;
				piece.Key = key;
				dictionary.Add(pieceName, piece);

			}
			string command = Console.ReadLine();

			while (command != "Stop")
			{
				string[] tokens = command.Split("|");

				if (tokens[0] == "Add")
				{
					string pieceName = tokens[1];
					string composer = tokens[2];
					string key = tokens[3];

					if (dictionary.ContainsKey(pieceName))
					{
                        Console.WriteLine($"{pieceName} is already in the collection!");
					}
					else
					{
						Piece piece = new Piece();
						piece.Composer = composer;
						piece.Key = key;
						if (isRemoved)
						{
							newDictionary.Add(pieceName, piece);
						}
						else
						{
							dictionary.Add(pieceName, piece);
						}
                        Console.WriteLine($"{pieceName} by {composer} in {key} added to the collection!");
					}
				}
				else if (tokens[0] == "Remove")
				{
					string piece = tokens[1];
					if (dictionary.ContainsKey(piece))
					{
						dictionary.Remove(piece);
						Console.WriteLine($"Successfully removed {piece}!");
						isRemoved = true;
						if (isRemoved)
						{
							newDictionary = new Dictionary<string, Piece>(dictionary);
						}
					}
					else
					{
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
					}
				}
				else if (tokens[0] == "ChangeKey")
				{
					string piece = tokens[1];
					string newKey = tokens[2];

					if (dictionary.ContainsKey(piece))
					{
						dictionary[piece].Key = newKey;
						Console.WriteLine($"Changed the key of {piece} to {newKey}!");
					}
					else
					{
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
					}
				}

				command = Console.ReadLine();
			}

			if (isRemoved)
			{
				foreach (var item in newDictionary)
				{
					Console.WriteLine($"{item.Key} -> Composer: {item.Value.Composer}, Key: {item.Value.Key}");
				}
			}
			else
			{
				foreach (var item in dictionary)
				{
					Console.WriteLine($"{item.Key} -> Composer: {item.Value.Composer}, Key: {item.Value.Key}");
				}
			}
		}

		public class Piece
		{
            public string Composer { get; set; }
            public string Key { get; set; }
        }
	}
}