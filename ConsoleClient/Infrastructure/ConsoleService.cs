using ConsoleClient.Entities;

namespace ConsoleClient.Infrastructure
{
    public class ConsoleService : IConsoleService
    {
        private readonly IWebApiService _webApiService;

        public ConsoleService(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }

        public async Task Start()
        {
            WriteConcoleMenu();
            while (true)
            {
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    Console.Write("Enter id customer: ");
                    string customerIdStr = Console.ReadLine();
                   
                    if (Int64.TryParse(customerIdStr, out _))
                    {
                        var customer = await _webApiService.GetCustomerByIdAsync(customerIdStr);
                        if (customer == null)
                        {
                            Console.WriteLine($"Not fount customer with id = {customerIdStr}");
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
                    WriteConcoleMenu();
                }
                else if (answer == "2")
                {
                    try
                    {
                        var rnd = new Random();
                        var customerId = rnd.Next(1, 10);
                        var customer = await _webApiService.GetCustomerByIdAsync(customerId.ToString());
                        if (customer == null)
                        {
                            var newId = await _webApiService.CreateCustomerAsync(customerId);
                            Console.WriteLine($"Generate customer with id = {customerId}");
                            Console.WriteLine($"Get data new customer...");
                            var newCustomer = await _webApiService.GetCustomerByIdAsync(newId);
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
    }
}
