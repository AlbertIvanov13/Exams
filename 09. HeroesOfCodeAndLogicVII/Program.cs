namespace _09._HeroesOfCodeAndLogicVII
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int heroesNumber = int.Parse(Console.ReadLine());

			Dictionary<string, Hero> heroesDict = new Dictionary<string, Hero>();

			for (int i = 0; i < heroesNumber; i++)
			{
				string[] heroes = Console.ReadLine().Split();
				string heroName = heroes[0];
				int hitPoints = int.Parse(heroes[1]);
				int manaPoints = int.Parse(heroes[2]);

				Hero hero = new Hero();
				hero.HitPoints = hitPoints;
				hero.ManaPoints = manaPoints;

				heroesDict.Add(heroName, hero);
			}

			string command = Console.ReadLine();

			while (command != "End")
			{
				string[] tokens = command.Split(" - ");

				if (tokens[0] == "CastSpell")
				{
					string heroName = tokens[1];
					int manaPoints = int.Parse(tokens[2]);
					string spellName = tokens[3];

					if (manaPoints <= heroesDict[heroName].ManaPoints)
					{
						heroesDict[heroName].ManaPoints -= manaPoints;
						int manaPointsLeft = heroesDict[heroName].ManaPoints;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {manaPointsLeft} MP!");
					}
					else
					{
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
					}
				}
				else if (tokens[0] == "TakeDamage")
				{
					string heroName = tokens[1];
					int damage = int.Parse(tokens[2]);
					string attacker = tokens[3];

					heroesDict[heroName].HitPoints -= damage;

					int reducedHP = heroesDict[heroName].HitPoints;

					if (reducedHP > 0)
					{
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {reducedHP} HP left!");
					}
					else
					{
						heroesDict.Remove(heroName);
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
					}
                }
				else if (tokens[0] == "Recharge")
				{
					string heroName = tokens[1];
					int amount = int.Parse(tokens[2]);

					int oldManaPoints = heroesDict[heroName].ManaPoints;

					heroesDict[heroName].ManaPoints += amount;

					int increasedMP = heroesDict[heroName].ManaPoints;

					if (increasedMP > 200)
					{
                        Console.WriteLine($"{heroName} recharged for {200 - oldManaPoints} MP!");
						heroesDict[heroName].ManaPoints = 200;
					}
					else
					{
                        Console.WriteLine($"{heroName} recharged for {amount} MP!");
					}
				}
				else if (tokens[0] == "Heal")
				{
					string heroName = tokens[1];
					int amount = int.Parse(tokens[2]);

					int oldHitPoints = heroesDict[heroName].HitPoints;

					heroesDict[heroName].HitPoints += amount;

					int healedHP = heroesDict[heroName].HitPoints;

					if (healedHP > 100)
					{
						Console.WriteLine($"{heroName} healed for {100 - oldHitPoints} HP!");
						heroesDict[heroName].HitPoints = 100;
					}
					else
					{
						Console.WriteLine($"{heroName} healed for {amount} HP!");
					}
				}

				command = Console.ReadLine();
			}

			foreach (var item in heroesDict)
			{
                Console.WriteLine(item.Key);
                Console.WriteLine($"  HP: {item.Value.HitPoints}");
                Console.WriteLine($"  MP: {item.Value.ManaPoints}");
			}
		}

		public class Hero
		{
            public int HitPoints { get; set; }
            public int ManaPoints { get; set; }
        }
	}
}