namespace AsyncBreakfast
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Before method call");
            
            Task<int> task1 = GetLuckyNumberAsync("task1", 2000);
            Task<int> task2 = GetLuckyNumberAsync("task2", 4000);

            Console.WriteLine("After method call");
            
            int result2 = await task2;
            int result1 = await task1;

            Console.WriteLine("After await !");
            Console.WriteLine($"result1: {result1}");
            Console.WriteLine($"result2: {result2}");
        }

        static async Task<int> GetLuckyNumberAsync(string str, int durationMilliSeconds)
        {
            Console.WriteLine($"Before Delay {str}");
            await Task.Delay(durationMilliSeconds);
            Console.WriteLine($"After Delay {str}");
            return 42;
        }
    }
}