using ConsoleClient.Entities;
using ConsoleClient.Repositories;
using System.Net.Http.Json;
using WebClient;

HttpClientHandler clientHandler = new HttpClientHandler();
clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
HttpClient client = new HttpClient(clientHandler);
client.BaseAddress = new Uri("https://localhost:5001/");

WriteConcoleMenu();
while (true)
{
    string answer = Console.ReadLine();
    if (answer == "1")
    {
        await GetCustomer(client);
        WriteConcoleMenu();
    }
    else if (answer == "2")
    {
        await GenerateCustomer(client);
        WriteConcoleMenu();
    }
    else if (answer == "3")
    {
        break;
    }
    else
    {
        Console.WriteLine("Unknown command");
        WriteConcoleMenu();
    }
}

static async Task GetCustomer(HttpClient client)
{
    Console.Write("Enter id customer: ");
    string customerIdStr = Console.ReadLine();
    long customerId;
    if (Int64.TryParse(customerIdStr, out customerId))
    {
        var customer = await CustomerRepositories.GetCustomerByIdAsync(client, customerId);
        if (customer == null)
        {
            Console.WriteLine($"Not fount customer with id = {customerId}");
        }
        else
        {
            PrintCustomer(customer);
        }
    }
    else
    {
        Console.WriteLine("Incorrect id value!");
    }
}

static async Task GenerateCustomer(HttpClient client)
{
    try
    {
        var rnd = new Random();
        var customerId = rnd.Next(1, 10);
        var customer = await CustomerRepositories.GetCustomerByIdAsync(client, customerId);
        if (customer == null)
        {
            var newId = await CustomerRepositories.CreateCustomerAsync(client, customerId);
            Console.WriteLine($"Generate customer with id = {customerId}");
            Console.WriteLine($"Get data new customer...");
            var newCustomer = await CustomerRepositories.GetCustomerByIdAsync(client, newId);
            PrintCustomer(newCustomer);
        }
        else
        {
            Console.WriteLine("The customer already exists");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Error create customer.");
    }
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

static void PrintCustomer(Customer customer)
{
    Console.WriteLine("Customer:");
    Console.WriteLine($"CustomerId = {customer.CustomerId}, FirstName = {customer.Firstname}, LastName = {customer.Lastname}.");
}