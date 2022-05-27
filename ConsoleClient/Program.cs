WriteConcoleMenu();
while (true)
{

}

static void WriteConcoleMenu()
{
    PrintConsoleSeparator();
    Console.WriteLine("Menu:");
    PrintConsoleSeparator();
    Console.WriteLine("Get data customer by id, enter  1");
    Console.WriteLine("Generate new customer, enter 2");
    Console.WriteLine("To exit, enter 3");
    PrintConsoleSeparator();
    Console.Write("Your choice: ");
}

static void PrintConsoleSeparator()
{
    Console.WriteLine(string.Concat(Enumerable.Repeat('-', 20)));
}