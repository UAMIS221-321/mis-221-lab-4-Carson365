
Console.WriteLine("Welcome to Crimson Crust!");

int choice = 1; // Setting this to a valid option for the first run so that the "Invalid choice" message isn't displayed.
Random rand = new Random();
while (choice != 4)
{
	do{
		if (choice < 1 || choice > 4) Console.WriteLine("Invalid choice. Please select an option from the menu below:");
		Console.WriteLine("1. Display a plain topping-less pizza slice");
		Console.WriteLine("2. Display a cheese pizza slice");
		Console.WriteLine("3. Display a pepperoni pizza slice");
		Console.WriteLine("4. Exit");
		Console.Write("Enter your choice: ");
	}
	while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4 );
	// Note that TryParse will set its out parameter to 0 if the input is not a valid integer.
	// This will trigger the "Invalid choice" message, since 0 falls outside the valid range of 1-4.

	Console.WriteLine(
		// Each pizza function returns the pizza slice as a string, so we can just print the result directly.
		choice == 1 ? $"Here is your plain pizza slice:\n\n{PlainPizza(rand)}" :
		choice == 2 ? $"Here is your cheese pizza slice:\n\n{CheesePizza(rand)}" :
		choice == 3 ? $"Here is your pepperoni pizza slice:\n\n{PepPizza(rand)}" :
		choice == 4 ? "Goodbye!" : "Invalid choice. Please select an option from the menu below:"
	);
}

static string PlainPizza(Random rnd){
	string slice = "";
	for (int i = rnd.Next(8,13); i > 0; i--)
	{
		for (int j = i; j > 0; j--) slice += "*\t"; // Crust
		slice += "\n";
	}
	return slice; // Enjoy your crust pizza
}

static string CheesePizza(Random rnd){
	string slice = "";
	int count = rnd.Next(8,13);
	for (int i = count; i > 0; i--)
	{
		for (int j = i; j > 0; j--)
		{
			if (i == count) slice += "*\t"; // First row is crust
			else if (j == i || j == 1) slice += "*\t"; // First and last columns are crust
			else slice += "#\t"; // Cheese
		}
		slice += "\n";
	}
	return slice;
}

static string PepPizza(Random rnd){
	string slice = "";
	int count = rnd.Next(8,13);
	for (int i = count; i > 0; i--)
	{
		for (int j = i; j > 0; j--)
		{
			bool pep = rnd.Next(0,5) == 1; // small chance of pepperoni
			if (i == count) slice += "*\t"; // First row is crust
			else if (j == i || j == 1) slice += "*\t"; // First and last columns are crust
			else if (pep) slice += "[]\t"; // Small chance of pepperoni
			else slice += "#\t"; // Cheese
		}
		slice += "\n";
	}
	return slice;
}