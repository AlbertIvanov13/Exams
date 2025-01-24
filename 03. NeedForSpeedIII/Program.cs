namespace _03._NeedForSpeedIII
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int carNumber = int.Parse(Console.ReadLine());

			Dictionary<string, Car> cars = new Dictionary<string, Car>();

			for (int i = 0;	i < carNumber; i++)
			{
				string[] tokens = Console.ReadLine().Split("|");

				string carName = tokens[0];
				int mileage = int.Parse(tokens[1]);
				int fuel = int.Parse(tokens[2]);

				Car car = new Car();
				car.Name = carName;
				car.Mileage = mileage;
				car.Fuel = fuel;

				cars.Add(carName, car);
			}

			string[] commands = Console.ReadLine().Split(" : ");

			while (commands[0] != "Stop")
			{
				if (commands[0] == "Drive")
				{
					string carName = commands[1];
					int distance = int.Parse(commands[2]);
					int consumedFuel = int.Parse(commands[3]);
					int remainingFuel = distance - consumedFuel;

					if (consumedFuel > 75 || consumedFuel > cars[carName].Fuel)
					{
                        Console.WriteLine("Not enough fuel to make that ride");
					}
					else
					{
						cars[carName].Mileage += distance;
						cars[carName].Fuel -= consumedFuel;
                        Console.WriteLine($"{carName} driven for {distance} kilometers. {consumedFuel} liters of fuel consumed.");
						if (cars[carName].Mileage >= 100000)
						{
							cars.Remove(carName);
                            Console.WriteLine($"Time to sell the {carName}!");
						}
					}
				}

				if (commands[0] == "Refuel")
				{
					string carName = commands[1];
					int fuel = int.Parse(commands[2]);
					int refuellableFuel = 75 - cars[carName].Fuel;
					int refuel = fuel + cars[carName].Fuel;

					if (refuel > 75)
					{
						cars[carName].Fuel = 75;
						Console.WriteLine($"{carName} refueled with {refuellableFuel} liters");
					}
					else
					{
						cars[carName].Fuel += fuel;
						Console.WriteLine($"{carName} refueled with {fuel} liters");
					}
				}

				if (commands[0] == "Revert")
				{
					string carName = commands[1];
					int kilometers = int.Parse(commands[2]);

					int decreasedMileage = cars[carName].Mileage -= kilometers;

					if (decreasedMileage < 10000)
					{
						cars[carName].Mileage = 10000;
					}
					else
					{
                        Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
					}
				}

				commands = Console.ReadLine().Split(" : ");
			}

			foreach (var car in cars)
			{
				Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
			}
		}

		public class Car
		{
            public string Name { get; set; }
            public int Mileage { get; set; }
            public int Fuel { get; set; }
        }
	}
}