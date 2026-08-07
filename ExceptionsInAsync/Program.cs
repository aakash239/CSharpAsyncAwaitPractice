namespace ExceptionsInAsync;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Before method call");

        try
        {
            int result = await GetRiskyNumberAsync();
            Console.WriteLine($"Got: {result}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Caught: {ex.Message}");
        }

        Console.WriteLine("After method call");
    }

    static async Task<int> GetRiskyNumberAsync()
    {
        Console.WriteLine("Before Delay");
        await Task.Delay(2000);
        Console.WriteLine("About to throw");
        throw new InvalidOperationException("Something went wrong!");
    }
}
